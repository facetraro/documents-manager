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
            return base.Equals(anotherBold) && IsTheSameApplication(anotherBold);
        }
        private bool IsTheSameApplication(Bold anotherBold)
        {
            return Applies == anotherBold.Applies;
        }
    }
}