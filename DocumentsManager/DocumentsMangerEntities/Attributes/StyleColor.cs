using DocumentsMangerEntities;

namespace DocumentsManagerTesting
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
    }
}