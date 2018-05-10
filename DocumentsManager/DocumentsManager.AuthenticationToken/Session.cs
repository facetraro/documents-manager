using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.AuthenticationToken
{
    public class Session
    {
        public Guid idLogged { get; set; }
        public Guid token { get; set; }
        public override bool Equals(object obj)
        {
            Session anotherSession = obj as Session;

            return anotherSession.token == token;
        }
    }
}
