using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    abstract public class StyleAttribute
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public StyleAttribute()
        {
            Id = Guid.NewGuid();
        }
        public override bool Equals(object obj)
        {
            bool validation = false;
            StyleAttribute anotherObject = obj as StyleAttribute;
            if (IsEqual(anotherObject))
            {
                validation = true;
            }
            return validation;
        }
        private bool IsEqual(StyleAttribute anotherObject)
        {
            return (System.Object)anotherObject != null && HasTheSameName(anotherObject);
        }
        private bool HasTheSameName(StyleAttribute anotherObject)
        {
            return anotherObject.Name == Name;
        }
    }
}
