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
            bool validation = false;
            StyleAttribute anotherObject = obj as StyleAttribute;
            if ((System.Object)anotherObject != null && anotherObject.Name==Name)
            {
                validation = true;
            }
            return validation;
        }
    }
}
