using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidValueForRanking : Exception
    {
        static string message = "La valoración debe ser entre 1 y 5";
        public InvalidValueForRanking() : base(message)
        {
        }
    }
}
