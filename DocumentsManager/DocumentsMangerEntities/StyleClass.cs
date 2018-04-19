using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class StyleClass
    {
        public StyleClass()
        {
            FontSize = new FontSize();
        }
        public TextAlignment Alignment { get; set; }
        public StyleClass Based { get; set; }
        public ApplyValue Bold { get; set; }
        public TextColor Color { get; set; }
        public FontType Font { get; set; }
        public FontSize FontSize { get; set; }
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
            StyleClass ret = new StyleClass();
            ret.Id = this.Id;
            if (this.Based.Alignment.Equals(TextAlignment.NotSpecified))
            {
                ret.Alignment = this.Alignment;
            }
            else
            {
                ret.Alignment = this.Based.Alignment;
            }
            if (this.Based.Bold.Equals(ApplyValue.NotSpecified))
            {
                ret.Bold = this.Bold;
            }
            else
            {
                ret.Bold = this.Based.Bold;
            }
            if (this.Based.Color.Equals(TextColor.NotSpecified))
            {
                ret.Color = this.Color;
            }
            else
            {
                ret.Color = this.Based.Color;
            }
            if (this.Based.Font.Equals(FontType.NotSpecified))
            {
                ret.Font = this.Font;
            }
            else
            {
                ret.Font = this.Based.Font;
            }
            if (this.Based.FontSize.Specified.Equals(SpecifiedValue.NotSpecified))
            {
                ret.FontSize = this.FontSize;
            }
            else
            {
                ret.FontSize = this.Based.FontSize;
            }
            if (this.Based.Italics.Equals(ApplyValue.NotSpecified))
            {
                ret.Italics = this.Italics;
            }
            else
            {
                ret.Italics = this.Based.Italics;
            }
            if (this.Based.Underline.Equals(ApplyValue.NotSpecified))
            {
                ret.Underline = this.Underline;
            }
            else
            {
                ret.Underline = this.Based.Underline;
            }
            return ret;
        }
    }
}
