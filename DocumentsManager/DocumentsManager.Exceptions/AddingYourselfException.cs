using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class AddingYourselfException: Exception
    {
        static string message = "No puedes agregarte a ti mismo";
        public AddingYourselfException() : base(message)
        {

        }
    }
}
