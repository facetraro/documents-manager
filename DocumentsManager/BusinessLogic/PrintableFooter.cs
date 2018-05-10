using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class PrintableFooter : IPrintableObject
    {
        public Footer FooterToPrint { get; set; }
        private FooterBusinessLogic footerBL;
        private StyleClassBusinessLogic StyleClassBL;
        public PrintableFooter(Footer aFooter)
        {
            FooterToPrint = aFooter;
            footerBL = new FooterBusinessLogic();
            StyleClassBL = new StyleClassBusinessLogic();
        }
        public string Print(Document containerDocument)
        {
            string closeBody = "</body>";
            string closeHtml = "</html>";
            Footer footer = footerBL.GetById(FooterToPrint.Id);
            StyleClass definedStyleClass = StyleClassBL.GetById(DefineStyleClass(containerDocument).Id);
            if (definedStyleClass == null) definedStyleClass = new StyleClass();
            string textToPrint = "<footer>" + StyleClassBL.GetHtmlText(definedStyleClass, footer.Text.WrittenText) + "</footer>";
            return textToPrint + closeBody + closeHtml;
        }

        public StyleClass DefineStyleClass(Document containerDocument)
        {
            TextBusinessLogic textBl = new TextBusinessLogic();
            FormatBusinessLogic formatBL = new FormatBusinessLogic();
            Format documentFormat = formatBL.GetByID(containerDocument.Format.Id);
            Footer theFooter = footerBL.GetById(FooterToPrint.Id);
            StyleClass suitableStyleClass = new StyleClass();
            Text text = textBl.GetById(theFooter.Text.Id);
            if (documentFormat.StyleClasses.Contains(text.StyleClass))
            {
                suitableStyleClass = text.StyleClass;
            }
            else
            {
                if (documentFormat.StyleClasses.Contains(theFooter.StyleClass))
                {
                    suitableStyleClass = theFooter.StyleClass;
                }
                else
                {
                    if (documentFormat.StyleClasses.Contains(containerDocument.StyleClass))
                    {
                        suitableStyleClass = containerDocument.StyleClass;
                    }
                }
            }
            return suitableStyleClass;
        }
    }
}
