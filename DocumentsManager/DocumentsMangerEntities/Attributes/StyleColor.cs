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
    }
}