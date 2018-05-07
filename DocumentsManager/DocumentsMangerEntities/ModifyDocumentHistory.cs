using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class ModifyDocumentHistory
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Document Document { get; set; }
        public DateTime Date { get; set; }
        public override bool Equals(object obj)
        {
            ModifyDocumentHistory anotherHistory = obj as ModifyDocumentHistory;
            if ((System.Object)anotherHistory == null)
            {
                return false;
            }
            return Id.Equals(anotherHistory.Id);    
        }
    }
}
