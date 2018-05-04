using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public abstract class DocumentObject
    {
        public virtual StyleClass StyleClass { get; set; }
        public Guid Id { get; set; }

    }
}
