using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public override bool Equals(object obj)
        {
            User anotherUser = obj as User;
            if ((System.Object)anotherUser == null)
            {
                return false;
            }
            return Id.Equals(anotherUser.Id);
        }
        public bool IsSameUserByEmail(User anUser) {
            return Email.Equals(anUser.Email);
        }
        public bool IsSameUserByUsername(User anUser)
        {
            return Username.Equals(anUser.Username);
        }
    }
}
