using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class PrintableText
    {
        public Text TextToPrint { get; set; }
        private TextContext tContext;
        private StyleClassBusinessLogic StyleClassBL;
        private Parragraph containerParragraph;
        public PrintableText(Text aText, Parragraph aParagraph)
        {
            TextToPrint = aText;
            tContext = new TextContext();
            StyleClassBL = new StyleClassBusinessLogic();
            ParragraphContext pContext = new ParragraphContext();
            containerParragraph = pContext.GetById(aParagraph.Id);
        }
        public string Print(Document containerDocument)
        {
            Text theText = tContext.GetById(TextToPrint.Id);
            StyleClass definedStyleClass = StyleClassBL.GetById(DefineStyleClass(containerDocument).Id);
            if (definedStyleClass == null) definedStyleClass = new StyleClass();
            return StyleClassBL.GetHtmlText(definedStyleClass, theText.WrittenText);
        }

        public StyleClass DefineStyleClass(Document containerDocument)
        {
            FormatContext formatContext = new FormatContext();
            Format documentFormat = formatContext.GetById(containerDocument.Format.Id);
            Text theText = tContext.GetById(TextToPrint.Id);
            StyleClass suitableStyleClass = new StyleClass();
            if (documentFormat.StyleClasses.Contains(theText.StyleClass))
            {
                suitableStyleClass = theText.StyleClass;
            }
            else
            {
                if (documentFormat.StyleClasses.Contains(containerParragraph.StyleClass))
                {
                    suitableStyleClass = containerParragraph.StyleClass;
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
