using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Parragraph:DocumentObject
    {
        public Guid Id { get; set; }
        public List<Text> Texts { get; set; }
    }
}
