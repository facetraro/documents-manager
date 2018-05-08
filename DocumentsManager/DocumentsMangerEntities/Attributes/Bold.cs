using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class Bold : BooleanAttribute
    {
        public Bold()
        {
            Name = "Negrita";
        }

        public override string GetEndTag()
        {
            return $"</{GetHTMLValue()}>";
        }

        public override string GetInitialTag()
        {
            return $"<{GetHTMLValue()}>";
        }

        public override string GetStyle()
        {
            return String.Empty;
        }
        private string GetHTMLValue()
        {
            return "strong";
        }
    }
}