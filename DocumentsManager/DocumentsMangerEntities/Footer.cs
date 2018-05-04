using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Footer: DocumentObject
    {
        public virtual Text Text { get; set; }

        public override bool Equals(object obj)
        {
            Footer anotherFooter = obj as Footer;
            if ((System.Object)anotherFooter == null)
            {
                return false;
            }
            return Id.Equals(anotherFooter.Id);
        }
    }
}
