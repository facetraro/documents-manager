using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class StyleColor : StyleAttribute
    {
        public TextColor TextColor { get; set; }
        public StyleColor()
        {
            Name = "Color";
        }
        public override bool Equals(object obj)
        {
            StyleColor anotherStyleColor = obj as StyleColor;
            return base.Equals(anotherStyleColor) && IsSameColor(anotherStyleColor);
        }
        private bool IsSameColor(StyleColor anotherStyleColor)
        {
            return TextColor == anotherStyleColor.TextColor;
        }

        private string GetHTMLValue()
        {
            return $"color: {GetHTMLColor()}";
        }
        private string GetHTMLColor()
        {
            return TextColorToHTML.GetString(TextColor);
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

        public override string GetStringParse()
        {
            return base.ToString()+"###"+this.TextColor.GetStringParser();
        }
    }
}