using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class NoUserLoggedException:Exception
    {
        private static string message = "No hay ningun usuario logeado para hacer esa acción";
        public NoUserLoggedException() : base(message)
        {

        }
    }
}
