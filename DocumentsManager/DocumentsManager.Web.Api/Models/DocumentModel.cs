using DocumentsManager.BusinessLogic;
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
        public Guid FormatId { get; set; }
        public Guid StyleClassId { get; set; }
        public HeaderModel Header { get; set; }
        public FooterModel Footer { get; set; }
        public string Title { get; set; }
        public virtual List<ParragraphModel> Parragraphs { get; set; }
        public DocumentModel()
        {
            Id = Guid.NewGuid();
            FormatId = Guid.NewGuid();
            StyleClassId = Guid.NewGuid();
            Header = new HeaderModel();
            Footer = new FooterModel();
            Title = "";
            Parragraphs = new List<ParragraphModel>();
        }
        public DocumentModel(Document aDocument)
        {
            Id = Guid.NewGuid();
            FormatId = aDocument.Format.Id;
            StyleClassId = aDocument.StyleClass.Id;
            Header = new HeaderModel(aDocument.Header);
            Footer =  new FooterModel(aDocument.Footer);
            Title = aDocument.Title;
            Parragraphs = new List<ParragraphModel>();
            foreach (Parragraph pi in aDocument.Parragraphs)
            {
                Parragraphs.Add( new ParragraphModel(pi));
            }
        }

        public Document GetEntityModel()
        {
            StyleClassBusinessLogic styleBL = new StyleClassBusinessLogic();
            FormatBusinessLogic formatBL = new FormatBusinessLogic();
            Document document = new Document {
                Id = Guid.NewGuid(),
                Footer = new Footer(),
                Header = new Header(),
                Parragraphs = new List<Parragraph>(),
                Format = new Format(),
                StyleClass = new StyleClass(),
                Title = ""
            };
            
            if (!Id.Equals(Guid.Empty))
            {
                document.Id = Id;
            }
            if (!String.IsNullOrEmpty(Title))
            {
                document.Title = Title;
            }
            foreach (ParragraphModel pmi in Parragraphs)
            {
                document.Parragraphs.Add(pmi.GetEntityModel());
            }
            document.Header = Header.GetEntityModel();
            document.Footer = Footer.GetEntityModel();
            document.StyleClass = styleBL.GetById(StyleClassId);
            document.Format = formatBL.GetByID(FormatId);        
            return document;
        }
    }
}