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
            underline.Id = Guid.NewGuid();
            underline.Applies = ApplyValue.NoApply;
            Italics italics = new Italics();
            italics.Id = Guid.NewGuid();
            italics.Applies = ApplyValue.Apply;
            Bold bold = new Bold();
            bold.Id = Guid.NewGuid();
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
            testStyleClass.Name = "DefaultName";
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
            parragraphs.Add(EntitiesExampleInstances.TestParragraph());
            Document aDocument = new Document
            {
                Id = Guid.NewGuid(),
                Format = EntitiesExampleInstances.TestFormat(),
                Header = EntitiesExampleInstances.TestHeader(),
                Footer = EntitiesExampleInstances.TestFooter(),
                Parragraphs = parragraphs,
                StyleClass = EntitiesExampleInstances.TestStyleClass(),
                Title = "Default title"
            };

            return aDocument;
        }
        public static Document TestDocumentWithOneStyle()
        {
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(EntitiesExampleInstances.TestParragraph());
            Document aDocument = new Document
            {
                Id = Guid.NewGuid(),
                StyleClass = EntitiesExampleInstances.TestStyleClass(),
                Format = EntitiesExampleInstances.TestFormat(),
                Header = EntitiesExampleInstances.TestHeader(),
                Footer = EntitiesExampleInstances.TestFooter(),
                Parragraphs = parragraphs,
                Title = "Default title"
            };
            foreach (var item in aDocument.Parragraphs)
            {
                item.StyleClass = aDocument.StyleClass;
            }
            aDocument.Footer.StyleClass = aDocument.StyleClass;
            aDocument.Header.StyleClass = aDocument.StyleClass;
            aDocument.Format.StyleClasses[0] = aDocument.StyleClass;
            return aDocument;
        }
        public static ModifyDocumentHistory TestModifyDocumentHistory()
        {
            ModifyDocumentHistory history = new ModifyDocumentHistory
            {
                Id = Guid.NewGuid(),
                User = TestAdminUser(),
                Document = TestDocument(),
                Date = DateTime.Now,
                State = ModifyState.Added,
            };
            return history;
        }

    }
}
