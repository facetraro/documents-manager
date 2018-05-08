using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class Italics : BooleanAttribute
    {
        public Italics()
        {
            Name = "Cursiva";
        }

        public override string GetEndTag()
        {
            return $"</{GetHTMLValue()}>";
        }

        public string GetHTMLValue()
        {
            return "em";
        }

        public override string GetInitialTag()
        {
            return $"<{GetHTMLValue()}>";
        }

        public override string GetStyle()
        {
            return String.Empty;
        }
    }
}