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
    }
}