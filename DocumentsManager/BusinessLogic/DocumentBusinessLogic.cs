﻿using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManager.ProxyInterfaces;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class DocumentBusinessLogic : IDocumentBusinessLogic
    {
        private void LoadFooter(Document document)
        {
            FooterBusinessLogic footerLogic = new FooterBusinessLogic();
            document.Footer = footerLogic.GetById(document.Footer.Id);
        }
        private void LoadFormat(Document document)
        {
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            document.Format = formatLogic.GetFormatByID(document.Format.Id, Guid.NewGuid());
        }
        private void LoadHeader(Document document)
        {
            HeaderBusinessLogic headerLogic = new HeaderBusinessLogic();
            document.Header = headerLogic.GetById(document.Header.Id);
        }
        private void LoadStyleClass(Document document)
        {
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            document.StyleClass = styleClassLogic.GetStyleById(document.StyleClass.Id, Guid.NewGuid());
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
        public Document GetDocumentById(Guid id, Guid tokenId)
        {
            DocumentContext context = new DocumentContext();
            Document documentFromBD = context.GetById(id);
            LoadRelatinships(documentFromBD);
            return documentFromBD;
        }
        private bool IsStyleInBD(StyleClass style)
        {
            StyleClassBusinessLogic styleLogic = new StyleClassBusinessLogic();
            return styleLogic.Exists(style.Id);
        }
        private bool IsFormatInBD(Format format)
        {
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            return formatLogic.Exists(format.Id);
        }
        private bool AreRelationshipAdded(Document document)
        {
            if (!IsStyleInBD(document.StyleClass))
            {
                throw new ObjectDoesNotExists(document.StyleClass);
            }
            if (!IsFormatInBD(document.Format))
            {
                throw new ObjectDoesNotExists(document.Format);
            }
            return true;
        }
        public Guid Add(Document document)
        {
            Guid newId = Guid.NewGuid();
            document.Id = newId;
            AreRelationshipAdded(document);
            DocumentContext context = new DocumentContext();
            context.Add(document);
            return newId;
        }
        public string PrintDocument(Document aDocument, Guid tokenId)
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
        public IEnumerable<Document> GetAllDocuments(Guid tokenId)
        {
            DocumentContext context = new DocumentContext();
            List<Document> allNotDeletedDocuments = new List<Document>();
            foreach (var item in context.GetDocuments())
            {
                if (!AlreadyDeleted(item))
                {
                    allNotDeletedDocuments.Add(item);
                }
            }
            return allNotDeletedDocuments;
        }

        public Document GetById(Guid id)
        {
            DocumentContext context = new DocumentContext();
            Document document = new Document();
            if (Exists(id))
            {
                document=context.GetById(id);
            }
            else
            {
                throw new ObjectDoesNotExists(document);
            }
            return document;
        }
        public bool AlreadyDeleted(Document aDocument) {
            ModifyDocumentHistoryContext context = new ModifyDocumentHistoryContext();
            List<ModifyDocumentHistory> histories = context.GetAllHistories();
            foreach (ModifyDocumentHistory history in histories)
            {
                if (history.Document.Equals(aDocument) && (history.State == ModifyState.Removed))
                {
                    return true;
                }
            }
            return false;
        }

        private Header GetDocumentHeader(Guid id)
        {
            HeaderBusinessLogic bl = new HeaderBusinessLogic();
            return bl.GetById(GetById(id).Header.Id);
        }

        private Footer GetDocumentFooter(Guid id)
        {
            FooterBusinessLogic bl = new FooterBusinessLogic();
            return bl.GetById(GetById(id).Footer.Id);
        }

        private List<Parragraph> GetDocumentParragraphs(Guid id)
        {
            ParragraphBusinessLogic bl = new ParragraphBusinessLogic();
            List<Parragraph> completeParratgraphs = new List<Parragraph>();
            foreach (Parragraph pi in GetById(id).Parragraphs)
            {
                completeParratgraphs.Add(bl.GetById(pi.Id));
            }
            return completeParratgraphs;
        }

        public Document GetFullDocument(Guid id, Guid tokenId)
        {
            Document document = GetById(id);
            document.Footer = GetDocumentFooter(id);
            document.Header = GetDocumentHeader(id);
            document.Parragraphs = GetDocumentParragraphs(id);
            return document;
        }

        public bool Exists(Guid id)
        {
            DocumentContext context = new DocumentContext();
            Document aDoc = new Document();
            aDoc.Id = id;
            return context.Exists(aDoc);
        }
    }
}
