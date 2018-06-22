using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class NotFriendsException: Exception
    {
        static string message1 = "Tu y el usuario ";
        static string message2 = " no son amigos.";

        public NotFriendsException(string username) : base(message1 + username + message2)
        {
        }
    }
}
