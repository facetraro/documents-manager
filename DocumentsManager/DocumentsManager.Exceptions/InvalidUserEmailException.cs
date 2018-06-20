using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class InvalidUserEmailException: Exception
    {
        static string message = "El Email debe tener: \n- 1 sólo @. \n- almenos 4 caracteres antes y despues del @.";
        public InvalidUserEmailException() : base(message)
        {
        }
    }
}
