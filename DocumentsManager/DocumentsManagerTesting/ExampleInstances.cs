using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerTesting
{
    public static class ExampleInstances
    {
        public static User TestUser()
        {
            User user = new AdminUser
            {
                Id = Guid.NewGuid(),
                Username = "DefaultUsername",
                Password = "DefaultPassword",
                Name = "DefaultName",
                Surname = "DefaultSurname",
                Email = "DefaultEmail@DefaultEmail.com"
            };
            return user;
        }
        public static EditorUser TestEditorUser()
        {
            EditorUser user = new EditorUser
            {
                Id = Guid.NewGuid(),
                Username = "DefaultUsername",
                Password = "DefaultPassword",
                Name = "DefaultName",
                Surname = "DefaultSurname",
                Email = "DefaultEmail@DefaultEmail.com"
            };
            return user;
        }
        public static StyleClass TestStyleClass()
        {
            StyleClass testStyleClass = new StyleClass();
            testStyleClass.Underline = true;
            testStyleClass.Italics = false;
            testStyleClass.Bold = false;
            testStyleClass.FontSize = 10;
            testStyleClass.Alignment = TextAlignment.Center;
            testStyleClass.Color = TextColor.Red;
            testStyleClass.Font = FontType.Arial;
            testStyleClass.Id = Guid.NewGuid();
            return testStyleClass;
        }
        public static AdminUser TestAdminUser()
        {
            AdminUser user = new AdminUser
            {
                Id = Guid.NewGuid(),
                Username = "DefaultUsername",
                Password = "DefaultPassword",
                Name = "DefaultName",
                Surname = "DefaultSurname",
                Email = "DefaultEmail@DefaultEmail.com"
            };
            return user;
        }
    }
}
