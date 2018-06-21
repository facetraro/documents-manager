using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class AlreadyReviewDocument : Exception
    {
        static string message = "No se puede Valorizar un documento mas de una vez por usuario.";
        public AlreadyReviewDocument() : base(message)
        {

        }
    }
}
