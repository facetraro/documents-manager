using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class AlreadyFriendsException : Exception
    {
        private static string message1 = "Tu y el usuario ";
        private static string message2 = " ya son amigos.";

        public AlreadyFriendsException(string username) : base(message1 + username + message2)
        {
        }
    }
}
