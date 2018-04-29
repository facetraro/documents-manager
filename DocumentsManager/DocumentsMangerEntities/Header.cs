using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Header: DocumentObject
    {
        public Guid Id { get; set; }
        public Text Text { get; set; }

   
        public override bool Equals(object obj)
        {
            Header anotherHeader = obj as Header;
            if ((System.Object)anotherHeader == null)
            {
                return false;
            }
            return Id.Equals(anotherHeader.Id);
        }
    }
}