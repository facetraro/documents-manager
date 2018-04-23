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
            Font font = (Font)(obj);
            return base.Equals(obj)&&this.FontType== font.FontType;
        }
    }
}