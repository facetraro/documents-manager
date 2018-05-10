using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class EditorModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public EditorModel()
        {

        }
        public EditorModel(EditorUser editor)
        {
            Id = editor.Id;
            Username = editor.Username;
            Password = editor.Password;
            Name = editor.Name;
            Surname = editor.Surname;
            Email = editor.Email;
        }
        public EditorUser GetEntityModel()
        {
            EditorUser editor = new EditorUser();
            if (!Id.Equals(Guid.Empty))
            {
                editor.Id = Id;
            }
            if (!String.IsNullOrEmpty(Username))
            {
                editor.Username = Username;
            }
            if (!String.IsNullOrEmpty(Password))
            {
                editor.Password = Password;
            }
            if (!String.IsNullOrEmpty(Name))
            {
                editor.Name = Name;
            }
            if (!String.IsNullOrEmpty(Surname))
            {
                editor.Surname = Surname;
            }
            if (!String.IsNullOrEmpty(Email))
            {
                editor.Email = Email;
            }
            return editor;
        }
    }
}