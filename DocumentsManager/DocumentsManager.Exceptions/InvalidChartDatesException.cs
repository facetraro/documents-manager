using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidChartDatesException : Exception
    {
        private static string message = "La fecha [Desde] no puede ser despues que la fecha [Hasta]";
        public InvalidChartDatesException() : base(message)
        {
        }
    }
}
