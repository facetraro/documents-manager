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
        public override bool Equals(object obj)
        {
            Bold anotherBold = obj as Bold;
            return base.Equals(anotherBold) && IsEqual(anotherBold);
        }
        private bool IsEqual(Bold anotherBold)
        {
            return Applies == anotherBold.Applies;
        }
    }
}