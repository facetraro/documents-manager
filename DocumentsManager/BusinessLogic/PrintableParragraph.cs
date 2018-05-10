using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class PrintableParragraph : IPrintableObject
    {
        public Parragraph ParragraphToPrint { get; set; }
        private ParragraphContext pContext;
        public PrintableParragraph(Parragraph aParragraph)
        {
            ParragraphToPrint = aParragraph;
            pContext = new ParragraphContext();
        }
        public string Print(Document containerDocument)
        {
            string parragraphText = "<br>";
            Parragraph theParragraph = pContext.GetById(ParragraphToPrint.Id);
            List<Text> textsToPrint = theParragraph.Texts;
            foreach (Text textToPrint in textsToPrint)
            {
                PrintableText printableText = new PrintableText(textToPrint, ParragraphToPrint);
                parragraphText += printableText.Print(containerDocument);
            }
            parragraphText += "</br>";
            return parragraphText;
        }
    }
}
