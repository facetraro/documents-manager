using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class Underline : BooleanAttribute
    {
        public Underline()
        {
            Name = "Subrayado";
        }

        public override string GetEndTag()
        {
            return String.Empty;
        }

        public string GetHTMLValue()
        {
            return "text-decoration: underline";
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