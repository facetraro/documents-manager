using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    public class Font : StyleAttribute
    {
        public FontType FontType { get; set; }
        public Font()
        {
            Name = "Tipo de Letra";
        }
        public override bool Equals(object obj)
        {
            Font anotherFont = obj as Font;
            if ((System.Object)anotherFont == null)
            {
                return false;
            }
            return base.Equals(obj) && IsTheSameFont(anotherFont);
        }
        private bool IsTheSameFont(Font font)
        {
            return FontType == font.FontType;
        }
    }
}