using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    public class Italics : StyleAttribute
    {
        public ApplyValue Applies { get; set; }
        public Italics()
        {
            Name = "Cursiva";
        }
    }
}