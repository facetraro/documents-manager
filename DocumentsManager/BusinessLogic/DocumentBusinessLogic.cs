﻿using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
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
    }
}
