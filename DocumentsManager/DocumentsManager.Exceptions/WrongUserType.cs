using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class WrongUserType: Exception
    {
        static string message1 = "Ese usuario no es un ";
        static string message2 = ".";
        public WrongUserType(Object obj) : base(message1 + obj.GetType() + message2)
        {
        }
    }
}
