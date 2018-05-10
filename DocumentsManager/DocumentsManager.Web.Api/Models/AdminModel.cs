using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class AdminModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public AdminModel() {

        }
        public AdminModel(AdminUser admin)
        {
            Id = admin.Id;
            Username = admin.Username;
            Password = admin.Password;
            Name = admin.Name;
            Surname = admin.Surname;
            Email = admin.Email;
        }
        public AdminUser GetEntityModel() {
            AdminUser admin = new AdminUser();
            if (!Id.Equals(Guid.Empty))
            {
                admin.Id = Id;
            }
            if (!String.IsNullOrEmpty(Username))
            {
                admin.Username = Username;
            }
            if (!String.IsNullOrEmpty(Password))
            {
                admin.Password = Password;
            }
            if (!String.IsNullOrEmpty(Name))
            {
                admin.Name = Name;
            }
            if (!String.IsNullOrEmpty(Surname))
            {
                admin.Surname = Surname;
            }
            if (!String.IsNullOrEmpty(Email))
            {
                admin.Email = Email;
            }
            return admin;
        }
    }
}