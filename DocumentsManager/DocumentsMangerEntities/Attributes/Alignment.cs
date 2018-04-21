using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    public class Alignment : StyleAttribute
    {
        public TextAlignment TextAlignment { get; set; }
        public Alignment()
        {
            Name = "Alineación";
        }
    }
}