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
        public override bool Equals(object obj)
        {
            Alignment anotherAlignment = obj as Alignment;
            return base.Equals(obj) && anotherAlignment.TextAlignment==TextAlignment;
        }
    }
}