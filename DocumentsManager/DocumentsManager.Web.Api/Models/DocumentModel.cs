using DocumentsManager.BusinessLogic;
using DocumentsManager.Dtos;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class DocumentModel
    {
        public Guid Id { get; set; }
        public FormatDto Format { get; set; }
        public StyleClassDto Style { get; set; }
        public HeaderModel Header { get; set; }
        public FooterModel Footer { get; set; }
        public string Title { get; set; }
        public virtual List<ParragraphModel> Parragraphs { get; set; }
        public DocumentModel()
        {
            Id = Guid.NewGuid();
            Format = new FormatDto(new DocumentsMangerEntities.Format());
            Style = new StyleClassDto();
            Header = new HeaderModel();
            Footer = new FooterModel();
            Title = "";
            Parragraphs = new List<ParragraphModel>();
        }
        public DocumentModel(Document aDocument)
        {
            Id = Guid.NewGuid();
            Format = new FormatDto(aDocument.Format);
            Style = new StyleClassDto(aDocument.StyleClass);
            Header = new HeaderModel(aDocument.Header);
            Footer = new FooterModel(aDocument.Footer);
            Title = aDocument.Title;
            Parragraphs = new List<ParragraphModel>();
            foreach (Parragraph pi in aDocument.Parragraphs)
            {
                Parragraphs.Add(new ParragraphModel(pi));
            }
        }

        public Document GetEntityModel()
        {
            DocumentBusinessLogic documentBL = new DocumentBusinessLogic();

          
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            FormatBusinessLogic formatBL = new FormatBusinessLogic();
            Document document = new Document
            {
                Id = Guid.NewGuid(),
                Footer = new Footer(),
                Header = new Header(),
                Parragraphs = new List<Parragraph>(),
                Format = new Format(),
                StyleClass = new StyleClass(),
                Title = ""
            };

           
            if (!String.IsNullOrEmpty(Title))
            {
                document.Title = Title;
            }
            foreach (ParragraphModel pmi in Parragraphs)
            {
                document.Parragraphs.Add(pmi.GetEntityModel());
            }
            if (!Id.Equals(Guid.Empty))
            {
                Document oldDocument = documentBL.GetFullDocument(Id, Guid.NewGuid());
                document.Id = Id;
                Header.Id = oldDocument.Header.Id;
                Footer.Id = oldDocument.Footer.Id;
            }           
            document.Header = Header.GetEntityModel();
            document.Footer = Footer.GetEntityModel();
            document.StyleClass = styleBL.GetStyleById(Style.Id, Guid.NewGuid());
            document.Format = formatBL.GetFormatByID(Format.Id, Guid.NewGuid());
            return document;
        }
    }
}