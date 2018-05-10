using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class PrintableHeader : IPrintableObject
    {
        public Header HeaderToPrint { get; set; }
        private HeaderContext hContext;
        private StyleClassBusinessLogic StyleClassBL;
        public PrintableHeader(Header aHeader)
        {
            HeaderToPrint = aHeader;
            hContext = new HeaderContext();
            StyleClassBL = new StyleClassBusinessLogic();
        }
        public string Print(Document containerDocument)
        {
            string documentTitle = "<title>" + containerDocument.Title + "</title>";
            Header header = hContext.GetById(HeaderToPrint.Id);
            StyleClass definedStyleClass = StyleClassBL.GetById(DefineStyleClass(containerDocument).Id);
            if (definedStyleClass == null) definedStyleClass = new StyleClass();
            string textToPrint = "<head>" + StyleClassBL.GetHtmlText(definedStyleClass, header.Text.WrittenText) + "</head>";
            string openHtml = "<html>";
            string openBody = "<body>";
            return openHtml + openBody + documentTitle + textToPrint;
        }

        public StyleClass DefineStyleClass(Document containerDocument)
        {
            TextBusinessLogic textBL = new TextBusinessLogic();
            FormatBusinessLogic formatBL = new FormatBusinessLogic();
            Format documentFormat = formatBL.GetById(containerDocument.Format.Id);
            Header theHeader = hContext.GetById(HeaderToPrint.Id);
            Text text = textBL.GetById(theHeader.Text.Id);
            StyleClass suitableStyleClass = new StyleClass();

            if (documentFormat.StyleClasses.Contains(text.StyleClass))
            {
                suitableStyleClass = text.StyleClass;
            }
            else
            {
                if (documentFormat.StyleClasses.Contains(theHeader.StyleClass))
                {
                    suitableStyleClass = theHeader.StyleClass;
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
