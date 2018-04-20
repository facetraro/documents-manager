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
            testStyleClass.Underline = ApplyValue.NotSpecified;
            testStyleClass.Italics = ApplyValue.Apply;
            testStyleClass.Bold = ApplyValue.NoApply;
            testStyleClass.FontSize.Size = 10;
            testStyleClass.FontSize.Specified = SpecifiedValue.Specified;
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
        public static Format TestFormat()
        {
            List<StyleClass> styles = new List<StyleClass>();
            styles.Add(TestStyleClass());
            Format format = new Format
            {
                Id = Guid.NewGuid(),
                Name = "DefaultFormatName",
                StyleClasses = styles
            };
            return format;
        }
    }
}
