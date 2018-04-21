using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    abstract public class StyleAttribute
    {
        public String Name { get; set; }
        public override bool Equals(object obj)
        {
            StyleAttribute anotherObject = (StyleAttribute)obj;
            return Name == anotherObject.Name;
        }
    }
}
