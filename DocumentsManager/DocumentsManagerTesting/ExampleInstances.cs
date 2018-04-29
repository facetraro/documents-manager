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
        public static Header TestHeader()
        {
            Header aHeader = new Header
            {
                Id = Guid.NewGuid(),
                Text = TestText(),
                StyleClass = TestStyleClass()
            };
            return aHeader;
        }
        public static Footer TestFooter()
        {
            Footer aFooter = new Footer
            {
                Id = Guid.NewGuid(),
                Text = TestText(),
                StyleClass = TestStyleClass()
            };
            return aFooter;
        }
        public static Parragraph TestParragraph()
        {
            Text aText = TestText();
            List<Text> texts = new List<Text>();
            texts.Add(aText);
            Parragraph aParragraph = new Parragraph
            {
                Id = Guid.NewGuid(),
                Texts = texts,
                StyleClass = TestStyleClass()
            };
            return aParragraph;
        }
        public static Document TestDocument() 
        {
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(ExampleInstances.TestParragraph());
            Document aDocument = new Document {
                Id = Guid.NewGuid(),
                Format = ExampleInstances.TestFormat(),
                Header = ExampleInstances.TestHeader(),
                Footer = ExampleInstances.TestFooter(),
                Parragraphs = parragraphs,
                CreatorUser = ExampleInstances.TestUser(),
                StyleClass = ExampleInstances.TestStyleClass(),
                CreationDate = DateTime.Today,
                Title = "Default title"
        };
           
            return aDocument;
        }

    }
}
