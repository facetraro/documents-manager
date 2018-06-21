using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class NotAdminOrDoesntExistsException : Exception
    {
        static string message = "Esta aplicación es estrictamente para usuarios administradores registrados en el sistema";
        public NotAdminOrDoesntExistsException() : base(message) { }
    }
}
