using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Header
    {
        public Guid Id { get; set; }
        public Text Text { get; set; }
        public StyleClass StyleClass { get; set; }

    }
}
