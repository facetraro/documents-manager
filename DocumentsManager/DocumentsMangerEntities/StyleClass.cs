using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class StyleClass
    {
        public Guid Id { get; set; }
        public List<StyleAttribute> Attributes { get; set; }
        public StyleClass Based { get; set; }
        public StyleClass()
        {
            Attributes = new List<StyleAttribute>();
        }
        public override bool Equals(object obj)
        {
            StyleClass anotherStyleClass = obj as StyleClass;
            if ((System.Object)anotherStyleClass == null)
            {
                return false;
            }
            return Id.Equals(anotherStyleClass.Id);
        }
        public StyleAttribute GetAttributeByName(string name)
        {
            foreach (var item in Attributes)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public StyleClass GetBasedOnStyleClass()
        {
            StyleClass ret = new StyleClass();
            ret.Id = this.Id;
            ret.Attributes = Based.Attributes;
            foreach (var item in this.Attributes)
            {
                if (!ret.IsAttributeSpecified(item))
                {
                    ret.Attributes.Add(item);
                }
            }
            return ret;
        }
        public bool IsAttributeSpecified(StyleAttribute attribute)
        {

            foreach (var item in Attributes)
            {
                if (attribute.Name.Equals(item.Name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
