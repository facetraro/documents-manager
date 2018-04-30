using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerExampleInstances
{
    public class EntitiesExampleInstances
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
        public static List<StyleAttribute> TestAttributes()
        {
            List<StyleAttribute> attributes = new List<StyleAttribute>();
            Underline underline = new Underline();
            underline.Applies = ApplyValue.NoApply;
            Italics italics = new Italics();
            italics.Applies = ApplyValue.Apply;
            Bold bold = new Bold();
            bold.Applies = ApplyValue.NoApply;
            FontSize fontSize = new FontSize();
            fontSize.Size = 10;
            Alignment alignment = new Alignment();
            alignment.TextAlignment = TextAlignment.Center;
            StyleColor color = new StyleColor();
            color.TextColor = TextColor.Red;
            Font font = new Font();
            font.FontType = FontType.Arial;
            attributes.Add(underline);
            attributes.Add(italics);
            attributes.Add(bold);
            attributes.Add(fontSize);
            attributes.Add(alignment);
            attributes.Add(color);
            attributes.Add(font);
            return attributes;
        }
        public static StyleClass TestStyleClass()
        {
            StyleClass testStyleClass = new StyleClass();
            testStyleClass.Attributes = TestAttributes();
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
        public static Text TestText()
        {
            Text aText = new Text
            {
                Id = Guid.NewGuid(),
                WrittenText = "DefaultText",
                StyleClass = TestStyleClass()
            };
            return aText;
        }
    }
}
