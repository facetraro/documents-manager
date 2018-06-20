using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class NotEnoughDocumentsException : Exception
    {
        static string message = "Deben existir almenos 3 documentos valorizados para realizar la consulta requerida";
        public NotEnoughDocumentsException() : base(message)
        {
        }
    }
}
