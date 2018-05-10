using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class DocumentBusinessLogic
    {
        private void LoadFooter(Document document)
        {
            FooterBusinessLogic footerLogic = new FooterBusinessLogic();
            document.Footer = footerLogic.GetById(document.Footer.Id);
        }
        private void LoadFormat(Document document)
        {
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            document.Format = formatLogic.GetById(document.Format.Id);
        }
        private void LoadHeader(Document document)
        {
            HeaderBusinessLogic headerLogic = new HeaderBusinessLogic();
            document.Header = headerLogic.GetById(document.Header.Id);
        }
        private void LoadStyleClass(Document document)
        {
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            document.StyleClass = styleClassLogic.GetById(document.StyleClass.Id);
        }
        private void LoadParragraphs(Document document)
        {
            ParragraphBusinessLogic parragraphLogic = new ParragraphBusinessLogic();
            List<Parragraph> parragraphs = new List<Parragraph>();
            foreach (var item in document.Parragraphs)
            {
                parragraphs.Add(parragraphLogic.GetById(item.Id));
            }
            document.Parragraphs = parragraphs;
        }
        private void LoadRelatinships(Document document)
        {
            LoadFooter(document);
            LoadHeader(document);
            LoadFormat(document);
            LoadStyleClass(document);
            LoadParragraphs(document);
        }
        public Document GetDocumentById(Guid id)
        {
            DocumentContext context = new DocumentContext();
            Document documentFromBD = context.GetById(id);
            LoadRelatinships(documentFromBD);
            return documentFromBD;
        }
        public string PrintDocument(Document aDocument)
        {
            List<IPrintableObject> objectsToPrint = new List<IPrintableObject>();
            PrintableHeader headerToPrint = new PrintableHeader(aDocument.Header);
            objectsToPrint.Add(headerToPrint);
            PrintableFooter footerToPrint = new PrintableFooter(aDocument.Footer);
            foreach (Parragraph parragraphi in aDocument.Parragraphs)
            {
                PrintableParragraph parragraphToPrint = new PrintableParragraph(parragraphi);
                objectsToPrint.Add(parragraphToPrint);
            }
            objectsToPrint.Add(footerToPrint);
            return PrintDocumentsObjects(aDocument, objectsToPrint);
        }
        public string PrintDocumentsObjects(Document aDocument, List<IPrintableObject> printableObjects)
        {
            string htmlDocument = string.Empty;
            foreach (IPrintableObject printableObject in printableObjects)
            {
                htmlDocument += printableObject.Print(aDocument);
            }
            return htmlDocument;
        }
        public IEnumerable<Document> GetAllDocuments()
        {
            DocumentContext context = new DocumentContext();
            return context.GetDocuments();
        }

    }
}
