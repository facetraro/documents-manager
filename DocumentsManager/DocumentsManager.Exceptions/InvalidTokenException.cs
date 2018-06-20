using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidTokenException : Exception
    {
        static string message = "El Token no es válido";
        public InvalidTokenException() : base(message)
        {
        }
    }
}
