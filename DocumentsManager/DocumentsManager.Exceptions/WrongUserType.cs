using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class WrongUserType: Exception
    {
        private static string message1 = "Ese usuario no es un ";
        private static string message2 = ".";
        public WrongUserType(Object obj) : base(message1 + obj.GetType() + message2)
        {
        }
    }
}
