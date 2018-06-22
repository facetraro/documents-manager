using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class SessionExpiredException : Exception
    {
        static string message = "La sesión actual expiró o no existe.";
        public SessionExpiredException() : base(message)
        {

        }
    }
}
