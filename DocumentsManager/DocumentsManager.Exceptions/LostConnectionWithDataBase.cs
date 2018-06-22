using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class LostConnectionWithDataBase : Exception
    {
        static string message = "Se perdio la conexion con la Base de Datos";
        public LostConnectionWithDataBase() : base(message)
        {

        }
    }
}
