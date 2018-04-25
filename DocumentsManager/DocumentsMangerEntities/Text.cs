using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Text
    {
        public Guid Id { get; set; }
        public StyleClass StyleClass { get; set; }
        public string WrittenText { get; set; }
    }
}
