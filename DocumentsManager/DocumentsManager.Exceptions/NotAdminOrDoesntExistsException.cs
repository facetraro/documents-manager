using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class StyleHasStylesBasedOnHim : Exception
    {
        static string message = "Esta Clase Estilo tiene otros Estilos basados en él.";
        public StyleHasStylesBasedOnHim() : base(message) { }
    }
}
