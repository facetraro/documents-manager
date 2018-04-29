using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public abstract class BooleanAttribute : StyleAttribute
    {
        public ApplyValue Applies { get; set; }
        public override bool Equals(object obj)
        {
            BooleanAttribute anotherBooleanAttribute = obj as BooleanAttribute;
            return base.Equals(anotherBooleanAttribute) && IsTheSameApplication(anotherBooleanAttribute);
        }
        private bool IsTheSameApplication(BooleanAttribute anotherBold)
        {
            return Applies == anotherBold.Applies;
        }
    }
}
