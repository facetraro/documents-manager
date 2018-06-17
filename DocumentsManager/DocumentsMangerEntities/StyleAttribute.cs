using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    abstract public class StyleAttribute : IComparable<StyleAttribute>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public virtual StyleClass Style { get; set; }
        public StyleAttribute()
        {
            Id = Guid.NewGuid();
        }
        public virtual bool Equals(object obj)
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
        public abstract string GetStyle();
        public abstract string GetInitialTag();
        public abstract string GetEndTag();
        public override string ToString()
        {
            return this.Name; 
        }
        public int CompareTo(StyleAttribute other)
        {
            if (other == null)
                return 1;

            else
                return Name.CompareTo(other.Name);
        }

    }
}
