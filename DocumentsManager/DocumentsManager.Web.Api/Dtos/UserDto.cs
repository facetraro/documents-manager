using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserDto()
        {

        }
        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.Username;
            Password = "";
            Email = user.Email;
            Surname = user.Surname;
        }
        public User GetEntityModel()
        {
            User user = new EditorUser();
            if (!Id.Equals(Guid.Empty))
            {
                user.Id = Id;
            }
            if (!String.IsNullOrEmpty(Name))
            {
                user.Name = Name;
            }
            if (!String.IsNullOrEmpty(Username))
            {
                user.Username = Username;
            }
            if (!String.IsNullOrEmpty(Email))
            {
                user.Email = Email;
            }
            if (!String.IsNullOrEmpty(Surname))
            {
                user.Surname = Surname;
            }
            if (!String.IsNullOrEmpty(Password))
            {
                user.Password = Password;
            }

            return user;
        }
    }
}