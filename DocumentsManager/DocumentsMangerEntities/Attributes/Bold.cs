using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    public class Bold : StyleAttribute
    {
        public ApplyValue Applies { get; set; }
        public Bold()
        {
            Name = "Negrita";
        }
    }
}