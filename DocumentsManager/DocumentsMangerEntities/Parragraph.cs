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
        public override bool Equals(object obj)
        {
            Parragraph anotherParragraph = obj as Parragraph;
            if ((System.Object)anotherParragraph == null)
            {
                return false;
            }
            return Id.Equals(anotherParragraph.Id);
        }
    }
}
