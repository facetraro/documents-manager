using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class StyleClassUsedInAnotherElement : Exception
    {
        static string message = "StyleClass esta contenido en elemento ";
        public StyleClassUsedInAnotherElement(string element) : base("StyleClass esta contenido en elemento "+ element)
        {

        }
    }
}
