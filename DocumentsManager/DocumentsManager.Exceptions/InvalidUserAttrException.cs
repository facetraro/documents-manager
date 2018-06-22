using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidUserAttrException : Exception
    {
        static string message = " debe tener almenos 3 caracteres.";
        public InvalidUserAttrException(string atribute) : base("Error: El "+atribute+message)
        {
        }
    }
}
