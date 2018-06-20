using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class CantDeleteLoggedUserException : Exception
    {
        static string message = "No se puede eliminar el usuario que esta loggeado.";
        public CantDeleteLoggedUserException() : base(message)
        {
        }
    }
}
