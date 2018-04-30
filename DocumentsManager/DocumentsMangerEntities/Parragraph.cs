using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Parragraph:DocumentObject
    {
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
        public void AddText(Text aText) {
            Texts.Add(aText);
        }
    }
}
