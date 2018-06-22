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
        public bool IsSameUserByEmail(User anUser)
        {
            return Email.Equals(anUser.Email);
        }
        public bool IsSameUserByUsername(User anUser)
        {
            return Username.Equals(anUser.Username);
        }
        public bool hasSameInformation(User anUser)
        {
            bool password = Password.Equals(anUser.Password);
            bool name = Name.Equals(anUser.Name);
            bool surname = Surname.Equals(anUser.Surname);
            return IsSameUserByUsername(anUser) && IsSameUserByEmail(anUser) && password && name && surname && Equals(anUser);
        }
        public bool Authenticate(string possiblePassword)
        {
            return Password.Equals(possiblePassword);
        }
        public bool IsUserValid()
        {
            return IsEmailValid() && IsCommonAttrValid(this.Username) && IsPasswordValid() && IsCommonAttrValid(this.Name) && IsCommonAttrValid(this.Surname);
        }
        public bool IsEmailValid()
        {
            if (Email==null)return false;
            bool containsAt = Email.Contains("@");
            string[] splitedEmail = Email.Split('@');
            bool oneAt = splitedEmail.Length == 2;
            if (!oneAt )return false;
            bool notEmptySides = !splitedEmail[0].Equals("") && !splitedEmail[1].Equals("");
            bool lengthSides = splitedEmail[0].Length > 3 && splitedEmail[1].Length > 3;
            return containsAt && oneAt && notEmptySides && lengthSides;
        }
        public bool IsCommonAttrValid(string attr)
        {
            return attr!=null && attr.Length > 3 && !attr.Contains(" ");
        }
        public bool IsPasswordValid()
        {
            return Password != null && Password.Length > 3;
        }
    }
}
