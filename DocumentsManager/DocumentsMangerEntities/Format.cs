using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Format
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<StyleClass> StyleClasses { get; set; }
    }
}
