using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class ObjectDoesNotExists:Exception
    {
        static string message1 = "No se pudo encontrar. Ese ";
        static string message2 = " No existe";
        public ObjectDoesNotExists(Object obj) : base(message1 + obj.GetType() + message2)
        {
        }
    }
}
