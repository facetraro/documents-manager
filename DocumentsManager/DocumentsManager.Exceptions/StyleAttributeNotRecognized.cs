using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class StyleAttributeNotRecognized : Exception
    {
        static string firstPartMessage = "Error al parsear [";
        static string secondPartMessage = "]. StyleAttribute no reconocido en el sistema";
        public StyleAttributeNotRecognized(string value) : base(firstPartMessage+value+secondPartMessage)
        {

        }
    }
}
