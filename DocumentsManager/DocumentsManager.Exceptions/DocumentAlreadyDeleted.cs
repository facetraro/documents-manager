using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class DocumentAlreadyDeleted:Exception
    {
        static string message = "Este documento ya fue eliminado logicamente";
        public DocumentAlreadyDeleted() : base(message)
        {

        }
    }
}
