using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class StyleClass
    {
        public TextAlignment Alignment { get; set; }
        public StyleClass Based { get; set; }
        public ApplyValue Bold { get; set; }
        public TextColor Color { get; set; }
        public FontType Font { get; set; }
        public int FontSize { get; set; }
        public Guid Id { get; set; }
        public ApplyValue Italics { get; set; }
        public ApplyValue Underline { get; set; }
        public override bool Equals(object obj)
        {
            StyleClass anotherStyleClass = obj as StyleClass;
            if ((System.Object)anotherStyleClass == null)
            {
                return false;
            }
            return Id.Equals(anotherStyleClass.Id);
        }

        public StyleClass GetBasedOnStyleClass()
        {
            return this.Based;
        }
    }
}
