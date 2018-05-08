using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Document
    {
        public DateTime CreationDate { get; set; }
        public virtual User CreatorUser { get; set; }
        public virtual Footer Footer { get; set; }
        public virtual Format Format { get; set; }
        public virtual Header Header { get; set; }
        public Guid Id { get; set; }
        public virtual List<Parragraph> Parragraphs { get; set; }
        public virtual StyleClass StyleClass { get; set; }
        public string Title { get; set; }
        public Document copyDocument(Document aDocument) {
            CreationDate = aDocument.CreationDate;
            CreatorUser = aDocument.CreatorUser;
            Footer = aDocument.Footer;
            Format = aDocument.Format;
            Header = aDocument.Header;
            Id = aDocument.Id;
            StyleClass = aDocument.StyleClass;
            Title = aDocument.Title;
            Parragraphs = new List<Parragraph>();
            foreach (var item in aDocument.Parragraphs)
            {
                Parragraphs.Add(item);
            }
            return this;
        }
        public override bool Equals(object obj)
        {
            Document anotherDocument = obj as Document;
            if ((System.Object)anotherDocument == null)
            {
                return false;
            }
            return Id.Equals(anotherDocument.Id);
        }
        public void AddParragraph(Parragraph aParragraph) {
            Parragraphs.Add(aParragraph);
        }
    }
}
