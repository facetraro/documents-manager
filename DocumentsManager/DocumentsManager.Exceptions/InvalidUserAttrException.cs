using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidUserAttrException : Exception
    {
        private static string message = "Se deben cumplir las siguientes condiciones: \n1- El nombre debe tener almenos 3 caracteres.\n El nombre de usuario debe tener almenos 3 caracteres.\n la password debe tener almenos 4 caracteres.\n El email debe contener único @ y tener almenos 4 caracteres antes y despues";
        public InvalidUserAttrException() : base(message)
        {
        }
    }
}
