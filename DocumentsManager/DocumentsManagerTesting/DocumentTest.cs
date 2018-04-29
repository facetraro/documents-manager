using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void DocumentBuilderTest() {
            Document aDocument = new Document();
            Guid id = Guid.NewGuid();
            Format aFormat = ExampleInstances.TestFormat();
            Header aHeader = ExampleInstances.TestHeader();
            Footer aFooter = ExampleInstances.TestFooter();
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(ExampleInstances.TestParragraph());
            parragraphs.Add(ExampleInstances.TestParragraph());
            User anUser = ExampleInstances.TestUser();
            StyleClass aStyle = ExampleInstances.TestStyleClass();
            DateTime aDate = DateTime.Today;
            string title = "This is a Title";
            Document.Id = id;
            Document.Format = aFormat;
            Document.Header = aHeader;
            Document.Footer = aFooter;
            Document.Parragraphs = parragraphs;
            Document.CreatorUser = anUser;
            Document.StyleClass = aStyle;
            Document.CreationDate = aDate;
            Document.Title = title;
            Assert.AreEqual(Document.Id,id);
            Assert.AreEqual(Document.Format,aFormat);
            Assert.AreEqual(Document.Header,aHeader);
            Assert.AreEqual(Document.Footer,aFooter);
            Assert.AreEqual(Document.Parragraphs,parragraphs);
            Assert.AreEqual(Document.Creatoruser,anUser);
            Assert.AreEqual(Document.StyleClass,aStyle);
            Assert.AreEqual(Document.CreationDate,aDate);
            Assert.AreEqual(Document.Title, title);
        }
        [TestMethod]
        public void DocumentBuilderTestDifferentAttr()
        {
            Document aDocument = new Document();
            Guid id = Guid.NewGuid();
            Format aFormat = ExampleInstances.TestFormat();
            Header aHeader = ExampleInstances.TestHeader();
            Footer aFooter = ExampleInstances.TestFooter();
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(ExampleInstances.TestParragraph());
            parragraphs.Add(ExampleInstances.TestParragraph());
            User anUser = ExampleInstances.TestUser();
            StyleClass aStyle = ExampleInstances.TestStyleClass();
            DateTime aDate = DateTime.Today;
            string title = "This is a Title";
            Document.Id = id;
            Document.Format = aFormat;
            Document.Header = aHeader;
            Document.Footer = aFooter;
            Document.Parragraphs = parragraphs;
            Document.CreatorUser = anUser;
            Document.StyleClass = aStyle;
            Document.CreationDate = aDate;
            Document.Title = title;
            Assert.AreNotEqual(Document.Id, Guid.NewGuid());
            Assert.AreNotEqual(Document.Format, ExampleInstances.TestFormat());
            Assert.AreNotEqual(Document.Header, ExampleInstances.TestHeader());
            Assert.AreNotEqual(Document.Footer, ExampleInstances.TestFooter());
            Assert.AreNotEqual(Document.Parragraphs, new List<Parragraph>());
            Assert.AreNotEqual(Document.Creatoruser, ExampleInstances.TestUser());
            Assert.AreNotEqual(Document.StyleClass, ExampleInstances.TestStyleClass());
            Assert.AreNotEqual(Document.CreationDate, DateTime.Today.AddDays(1));
            Assert.AreNotEqual(Document.Title, "");
        }
    }
}
