using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class StyleBasedCicleDetected : Exception
    {

        public StyleBasedCicleDetected() : base("No se puede formar un ciclo de Estilos Basados")
        {
        }
    }
}
