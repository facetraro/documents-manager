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
        public override bool Equals(object obj)
        {
            Format anotherFormat = obj as Format;
            if ((System.Object)anotherFormat == null)
            {
                return false;
            }
            return Id.Equals(anotherFormat.Id);
        }
    }
}
