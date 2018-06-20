using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class DocumentDto
    {
        public virtual FooterDto Footer { get; set; }
        public virtual FormatDto Format { get; set; }
        public virtual HeaderDto Header { get; set; }
        public Guid Id { get; set; }
        public virtual List<ParragraphDto> Parragraphs { get; set; }
        public virtual StyleClassDto Style { get; set; }
        public string Title { get; set; }
        public DocumentDto(Document aDocument) {
            Footer = new FooterDto(aDocument.Footer);
            Format = new FormatDto(aDocument.Format);
            Header = new HeaderDto(aDocument.Header);
            Id = aDocument.Id;
            Style = new StyleClassDto(aDocument.StyleClass);
            Title = aDocument.Title;
            Parragraphs = new List<ParragraphDto>();
            List<Parragraph> parragraps = aDocument.Parragraphs;
            foreach (var item in parragraps)
            {
                Parragraphs.Add(new ParragraphDto(item));
            }
        }
    }
}