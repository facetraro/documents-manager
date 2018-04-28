using DocumentsMangerEntities;
using DocumentsMangerEntities.Attributes;

namespace DocumentsManagerTesting
{
    public class Bold : BooleanAttribute
    {
        public Bold()
        {
            Name = "Negrita";
        }
    }
}