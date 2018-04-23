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
            bool validation = false;
            Font anotherFont = obj as Font;
            if ((System.Object)anotherFont != null)
            {
                return base.Equals(obj) && IsTheSameFont(anotherFont);
            }
            return validation;
        }
        private bool IsTheSameFont(Font font)
        {
            return FontType == font.FontType;
        }
    }
}