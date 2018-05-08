using System;
using DocumentsMangerEntities;

namespace DocumentsMangerEntities
{
    public class Alignment : StyleAttribute
    {
        public TextAlignment TextAlignment { get; set; }
        public Alignment()
        {
            Name = "Alineación";
        }
        public override bool Equals(object obj)
        {
            Alignment anotherAlignment = obj as Alignment;
            return base.Equals(obj) && IsTheSameAlignment(anotherAlignment);
        }
        private bool IsTheSameAlignment(Alignment anotherAlignment)
        {
            return anotherAlignment.TextAlignment == TextAlignment;
        }

        private string GetHTMLValue()
        {
            return $" text-align: {GetHTMLAlignment()} ; ";
        }
        private string GetHTMLAlignment()
        {
            return TextAlignmentToHTML.GetString(TextAlignment);
        }

        public override string GetStyle()
        {
            return this.GetHTMLValue();
        }

        public override string GetInitialTag()
        {
            return String.Empty;
        }

        public override string GetEndTag()
        {
            return String.Empty;
        }
    }
}