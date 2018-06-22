using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class AlreadySentRequestException : Exception
    {
        static string message = "Ya le has enviado una solicitud al usuario ";

        public AlreadySentRequestException(string username) : base(message + username)
        {
        }
    }
}
