using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidCredentialException : Exception
    {
        static string message = "La contraseña ingresada no es correcta";
        public InvalidCredentialException() : base(message)
        {

        }
    }
}
