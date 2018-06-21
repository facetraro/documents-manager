using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class UserNotRegisteredException: Exception
    {
        static string message = "ese usuario no existe.";
        public UserNotRegisteredException() : base(message) { }
    }
}
