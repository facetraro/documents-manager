using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidUserPasswordException: Exception
    {
        private static string message = "La contraseña debe tener almenos 4 caracteres.";
        public InvalidUserPasswordException() : base(message)
        {
        }
    }
}
