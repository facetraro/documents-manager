using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class Border : BooleanAttribute
    {
        public Border()
        {
            Name = "Borde";
        }

        public override string GetEndTag()
        {
            return String.Empty;
        }

        public string GetHTMLValue()
        {
            return "border: solid";
        }

        public override string GetInitialTag()
        {
            return String.Empty;
        }

        public override string GetStyle()
        {
            return $" {GetHTMLValue()} ; ";
        }
    }
}