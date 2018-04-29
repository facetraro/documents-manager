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
        public User CreatorUser { get; set; }
        public Footer Footer { get; set; }
        public Format Format { get; set; }
        public Header Header { get; set; }
        public Guid Id { get; set; }
        public List<Parragraph> Parragraphs { get; set; }
        public StyleClass StyleClass { get; set; }
        public string Title { get; set; }
    }
}
