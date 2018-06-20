using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class UserNotAuthorizedException : Exception
    {
        static string message = "El usuario no esta autorizado a ingresar a este sitio.";
        public UserNotAuthorizedException() : base(message)
        {

        }
    }
}
