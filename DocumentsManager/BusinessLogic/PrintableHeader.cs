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
            string textToPrint = "<head>" + StyleClassBL.GetHtmlText(DefineStyleClass(containerDocument), header.Text.WrittenText) + "</head>";
            string openHtml = "<html>";
            string openBody = "<body>";
            return openHtml + openBody + documentTitle + textToPrint;
        }

        public StyleClass DefineStyleClass(Document containerDocument)
        {

            TextContext tContext = new TextContext();
            StyleClassContextHandler scContext = new StyleClassContextHandler();
            FormatContext formatContext = new FormatContext();
            Format documentFormat = formatContext.GetById(containerDocument.Format.Id);
            Header theHeader = hContext.GetById(HeaderToPrint.Id);
            Text text = tContext.GetById(theHeader.Text.Id);
            StyleClass suitableStyleClass = new StyleClass();
            StyleClass headerStyle = scContext.GetById(theHeader.StyleClass.Id);
            StyleClass textStyle = scContext.GetById(text.StyleClass.Id);

            if (documentFormat.StyleClasses.Contains(textStyle))
            {
                suitableStyleClass = textStyle;
            }
            else
            {
                if (documentFormat.StyleClasses.Contains(headerStyle))
                {
                    suitableStyleClass = headerStyle;
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
