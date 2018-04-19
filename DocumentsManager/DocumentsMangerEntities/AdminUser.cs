using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class AdminUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            AdminUser anotherAdminUser = obj as AdminUser;
            if ((System.Object)anotherAdminUser == null)
            {
                return false;
            }
            return Id.Equals(anotherAdminUser.Id);
        }
    }
}
