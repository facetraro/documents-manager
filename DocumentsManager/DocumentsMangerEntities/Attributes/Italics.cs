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
        public override bool Equals(object obj)
        {
            Italics anotherItalics = obj as Italics;
            return base.Equals(obj) && Applies == anotherItalics.Applies;
        }
    }
}