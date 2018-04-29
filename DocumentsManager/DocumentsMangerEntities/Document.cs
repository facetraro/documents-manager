using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Document
    {
        public static DateTime CreationDate { get; set; }
        public static User CreatorUser { get; set; }
        public static Footer Footer { get; set; }
        public static Format Format { get; set; }
        public static Header Header { get; set; }
        public static Guid Id { get; set; }
        public static List<Parragraph> Parragraphs { get; set; }
        public static StyleClass StyleClass { get; set; }
        public static string Title { get; set; }
    }
}
