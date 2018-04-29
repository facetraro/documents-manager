using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Footer: DocumentObject
    {
        public Guid Id { get; set; }
        public Text Text { get; set; }

    }
}
