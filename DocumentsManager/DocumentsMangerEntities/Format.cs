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
        public virtual List<StyleClass> StyleClasses { get; set; }
        public Format()
        {
            StyleClasses = new List<StyleClass>();
        }
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
