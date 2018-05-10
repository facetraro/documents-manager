using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class UserAlreadyLogged : Exception
    {
        private static string message = "El usuario ya tiene una sesion iniciada en el sistema.";
        public UserAlreadyLogged() : base(message)
        {
        }
    }
}
