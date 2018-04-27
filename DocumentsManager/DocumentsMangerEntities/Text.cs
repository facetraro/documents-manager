using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Text
    {
        public Guid Id { get; set; }
        public StyleClass StyleClass { get; set; }
        public string WrittenText { get; set; }
   
    public override bool Equals(object obj)
    {
        Text anotherText = obj as Text;
        if ((System.Object)anotherText == null)
        {
            return false;
        }
        return Id.Equals(anotherText.Id);
    }
    }
}
