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
        private FooterContext fContext;
        private StyleClassBusinessLogic StyleClassBL;
        public PrintableFooter(Footer aFooter)
        {
            FooterToPrint = aFooter;
            fContext = new FooterContext();
            StyleClassBL = new StyleClassBusinessLogic();
        }
        public string Print(Document containerDocument)
        {
            string closeBody = "</body>";
            string closeHtml = "</html>";
            Footer footer = fContext.GetById(FooterToPrint.Id);
            string textToPrint = "<footer>" + StyleClassBL.GetHtmlText(DefineStyleClass(containerDocument), footer.Text.WrittenText) + "</footer>";
            return textToPrint + closeBody + closeHtml;
        }

        public StyleClass DefineStyleClass(Document containerDocument)
        {
            TextContext tContext = new TextContext();
            FormatContext formatContext = new FormatContext();
            Format documentFormat = formatContext.GetById(containerDocument.Format.Id);
            Footer theFooter = fContext.GetById(FooterToPrint.Id);
            StyleClass suitableStyleClass = new StyleClass();
            Text text = tContext.GetById(theFooter.Text.Id);
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
