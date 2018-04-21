using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    public class Underline : StyleAttribute
    {
        public ApplyValue Applies { get; set; }
        public Underline()
        {
            Name = "Subrayado";
        }
    }
}