using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class Font : StyleAttribute
    {
        public FontType FontType { get; set; }
        public Font()
        {
            Name = "TipoLetra";
        }
        public override bool Equals(object obj)
        {
            bool validation = false;
            Font anotherFont = obj as Font;
            validation = base.Equals(obj) && IsEqual(anotherFont);
            return validation;
        }
        private bool IsEqual(Font anotherFont)
        {
            bool validation = false;
            validation = IsTheSameFont(anotherFont);
            return validation;
        }
        private bool IsTheSameFont(Font font)
        {
            return FontType == font.FontType;
        }

        public string GetHTMLValue()
        {
            return $"font-family: {GetHTMLFont()}";
        }
        private string GetHTMLFont()
        {
            return FontTypeToHTML.GetString(FontType);
        }

        public override string GetStyle()
        {
            return $" {GetHTMLValue()} ; ";
        }

        public override string GetInitialTag()
        {
            return String.Empty;
        }

        public override string GetEndTag()
        {
            return String.Empty;
        }
        public override string ToString()
        {
            return base.ToString()+"###"+this.FontType.GetStringParser(); 
        }
    }
}