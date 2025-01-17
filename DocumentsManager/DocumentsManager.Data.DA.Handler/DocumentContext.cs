﻿using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class DocumentContext
    {
        public void ClearAll()
        {
            foreach (var item in GetLazy())
            {
                Remove(item);
            }
        }
        public List<Document> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.DocumentRepository.Get().ToList();
            }
        }
        private void AddDocumentParts(Document aDocument)
        {
            FooterContext fContext = new FooterContext();
            HeaderContext hContext = new HeaderContext();
            fContext.Add(aDocument.Footer);
            hContext.Add(aDocument.Header);
        }
        private void DeleteDocumentParragraphs(Document aDocument)
        {
            ParragraphContext pContext = new ParragraphContext();
            foreach (Parragraph parragraphi in aDocument.Parragraphs)
            {
                pContext.Remove(parragraphi);
            }
        }
        private void AddDocumentParragraphs(List<Parragraph> theParragraphs, Document modifiedDocument)
        {
            ParragraphContext pContext = new ParragraphContext();
            for (int i = 0; i < theParragraphs.Count; i++)
            {
                Parragraph parragraphi = theParragraphs.ElementAt(i);
                if (pContext.Exists(parragraphi))
                {
                    parragraphi = pContext.GetById(parragraphi.Id);
                    using (var db = new ContextDataAccess())
                    {
                        db.Parragraphs.Attach(parragraphi);
                    }
                }
                else
                {
                    parragraphi.Document = modifiedDocument;
                    pContext.Add(parragraphi);
                }
            }
        }
        public void Add(Document aDocument)
        {
            AddDocumentParts(aDocument);
            List<Parragraph> theParragraphs = aDocument.Parragraphs;
            aDocument.Parragraphs = new List<Parragraph>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(aDocument.StyleClass);
                aDocument.Format = db.Formats.Find(aDocument.Format.Id);
                aDocument.Footer = db.Footers.Find(aDocument.Footer.Id);
                aDocument.Header = db.Headers.Find(aDocument.Header.Id);
                unitOfWork.DocumentRepository.Insert(aDocument);
            }
            AddDocumentParragraphs(theParragraphs, aDocument);
            aDocument.Parragraphs = theParragraphs;
        }

        public void ModifyParragraphs(Document aDocument)
        {
            Document oldDocument = GetById(aDocument.Id);
            DeleteDocumentParragraphs(oldDocument);
            AddDocumentParragraphs(aDocument.Parragraphs, aDocument);
        }

        public void ModifyHeader(Document aDocument)
        {
            HeaderContext headerCtx = new HeaderContext();
            headerCtx.Modify(aDocument.Header);
        }

        private void DeleteDocumentParts(Document aDocument)
        {
            FooterContext fContext = new FooterContext();
            HeaderContext hContext = new HeaderContext();
            fContext.Remove(aDocument.Footer);
            hContext.Remove(aDocument.Header);
        }

        public void ModifyFooter(Document aDocument)
        {
            FooterContext footerCtx = new FooterContext();
            footerCtx.Modify(aDocument.Footer);
        }

        private void RemoveDocumentParagraphs(Document aDocument)
        {
            Document document = GetById(aDocument.Id);
            int lenghtParragraphs = document.Parragraphs.Count;
            ParragraphContext pContext = new ParragraphContext();
            for (int i = 0; i < lenghtParragraphs; i++)
            {
                pContext.Remove(document.Parragraphs.ElementAt(i));
            }
        }

        public void ModifyProperties(Document aDocument)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Document documenthEntity = db.Documents.Find(aDocument.Id);
                documenthEntity.Parragraphs = new List<Parragraph>();
                documenthEntity.StyleClass = db.Styles.Find(aDocument.StyleClass.Id);
                documenthEntity.Format = db.Formats.Find(aDocument.Format.Id);
                documenthEntity.Footer = db.Footers.Find(aDocument.Footer.Id);
                documenthEntity.Header = db.Headers.Find(aDocument.Header.Id);
                documenthEntity.Title = aDocument.Title;
                unitOfWork.DocumentRepository.Update(documenthEntity);
                unitOfWork.Save();
            }
        }

        public void Remove(Document documentToDelete)
        {
            Document document = new Document();
            RemoveDocumentParagraphs(documentToDelete);
            Document documentFromDB = GetById(documentToDelete.Id);
            documentToDelete.Parragraphs = new List<Parragraph>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                document = GetById(documentToDelete.Id);
                document.StyleClass = null;
                document.Footer.StyleClass = null;
                document.Header.StyleClass = null;
                document.Footer.Text.StyleClass = null;
                document.Header.Text.StyleClass = null;
                unitOfWork.DocumentRepository.Delete(document);
            }
            DeleteDocumentParts(documentFromDB);
        }

        public List<Parragraph> GetParragraphOfDocument(Document aDocument)
        {
            ParragraphContext context = new ParragraphContext();
            List<Parragraph> parragraphs = new List<Parragraph>();
            foreach (var item in context.GetLazy())
            {
                Parragraph aParragraph = context.GetById(item.Id);
                if (aParragraph.Document.Equals(aDocument))
                {
                    parragraphs.Add(aParragraph);
                }
            }
            return parragraphs;
        }

        public Document GetById(Guid id)
        {
            ParragraphContext pContext = new ParragraphContext();
            FooterContext fContext = new FooterContext();
            HeaderContext hContext = new HeaderContext();
            StyleClassContextHandler sContext = new StyleClassContextHandler();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Document theDocument = unitOfWork.DocumentRepository.GetByID(id);
                db.Documents.Include("StyleClass").ToList().FirstOrDefault();
                db.Documents.Include("Footer").ToList().FirstOrDefault();
                db.Documents.Include("Header").ToList().FirstOrDefault();
                db.Documents.Include("Format").ToList().FirstOrDefault();
                db.Documents.Include("Parragraphs").ToList();
                if (theDocument != null)
                {
                    List<Parragraph> eagerParragraphs = new List<Parragraph>();
                    foreach (Parragraph pi in theDocument.Parragraphs)
                    {
                        eagerParragraphs.Add(pContext.GetById(pi.Id));
                    }
                    theDocument.Parragraphs = eagerParragraphs;
                    theDocument.Footer = fContext.GetById(theDocument.Footer.Id);
                    theDocument.Header = hContext.GetById(theDocument.Header.Id);
                    theDocument.StyleClass = sContext.GetById(theDocument.StyleClass.Id);

                }

                return theDocument;
            }
        }
        public void Remove(Guid id)
        {
            Document toDelete = GetById(id);
            if (toDelete != null)
            {
                Remove(toDelete);
            }
        }
        private void transferParragraphInformation(Document modifiedDocument, Document oldDocument)
        {
            ParragraphContext contextP = new ParragraphContext();
            for (int i = 0; i < modifiedDocument.Parragraphs.Count; i++)
            {
                if (contextP.Exists(modifiedDocument.Parragraphs.ElementAt(i)))
                {
                    modifiedDocument.Parragraphs.ElementAt(i).StyleClass = contextP.GetById(modifiedDocument.Parragraphs.ElementAt(i).Id).StyleClass;

                }
            }
            for (int i = 0; i < oldDocument.Parragraphs.Count; i++)
            {
                contextP.Remove(oldDocument.Parragraphs.ElementAt(i));
            }
        }
        public void Modify(Document modifiedDocument, Document oldDocument)
        {
            modifiedDocument.StyleClass.Attributes = new List<StyleAttribute>();
            transferParragraphInformation(modifiedDocument, oldDocument);
            AddDocumentParts(modifiedDocument);

            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Document documenthEntity = db.Documents.Find(modifiedDocument.Id);
                documenthEntity.Parragraphs = new List<Parragraph>();
                documenthEntity.StyleClass = modifiedDocument.StyleClass;
                db.Styles.Attach(documenthEntity.StyleClass);
                documenthEntity.Format = db.Formats.Find(modifiedDocument.Format.Id);
                documenthEntity.Footer = db.Footers.Find(modifiedDocument.Footer.Id);
                documenthEntity.Header = db.Headers.Find(modifiedDocument.Header.Id);
                unitOfWork.DocumentRepository.Update(documenthEntity);
                unitOfWork.Save();
            }
            DeleteDocumentParts(oldDocument);
            AddDocumentParragraphs(modifiedDocument.Parragraphs, modifiedDocument);
        }
        public List<Document> GetDocuments()
        {
            List<Document> CompleteDocuments = new List<Document>();
            List<Document> documents = new List<Document>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                documents = unitOfWork.DocumentRepository.Get().ToList();
            }
            foreach (var item in documents)
            {
                CompleteDocuments.Add(GetById(item.Id));
            }
            return CompleteDocuments;
        }
        public bool Exists(Document aDocument)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.DocumentRepository.Exists(aDocument.Id);
            }
        }
    }
}
