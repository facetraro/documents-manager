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
            aDocument.Id = id;
            aDocument.Format = aFormat;
            aDocument.Header = aHeader;
            aDocument.Footer = aFooter;
            aDocument.Parragraphs = parragraphs;
            aDocument.CreatorUser = anUser;
            aDocument.StyleClass = aStyle;
            aDocument.CreationDate = aDate;
            aDocument.Title = title;
            Assert.AreEqual(aDocument.Id,id);
            Assert.AreEqual(aDocument.Format,aFormat);
            Assert.AreEqual(aDocument.Header,aHeader);
            Assert.AreEqual(aDocument.Footer,aFooter);
            Assert.AreEqual(aDocument.Parragraphs,parragraphs);
            Assert.AreEqual(aDocument.CreatorUser,anUser);
            Assert.AreEqual(aDocument.StyleClass,aStyle);
            Assert.AreEqual(aDocument.CreationDate,aDate);
            Assert.AreEqual(aDocument.Title, title);
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
            aDocument.Id = id;
            aDocument.Format = aFormat;
            aDocument.Header = aHeader;
            aDocument.Footer = aFooter;
            aDocument.Parragraphs = parragraphs;
            aDocument.CreatorUser = anUser;
            aDocument.StyleClass = aStyle;
            aDocument.CreationDate = aDate;
            aDocument.Title = title;
            Assert.AreNotEqual(aDocument.Id, Guid.NewGuid());
            Assert.AreNotEqual(aDocument.Format, ExampleInstances.TestFormat());
            Assert.AreNotEqual(aDocument.Header, ExampleInstances.TestHeader());
            Assert.AreNotEqual(aDocument.Footer, ExampleInstances.TestFooter());
            Assert.AreNotEqual(aDocument.Parragraphs, new List<Parragraph>());
            Assert.AreNotEqual(aDocument.CreatorUser, ExampleInstances.TestUser());
            Assert.AreNotEqual(aDocument.StyleClass, ExampleInstances.TestStyleClass());
            Assert.AreNotEqual(aDocument.CreationDate, DateTime.Today.AddDays(1));
            Assert.AreNotEqual(aDocument.Title, "");
        }
        [TestMethod]
        public void DocumentEqualsTestSameAttr()
        {
            Document aDocument = ExampleInstances.TestDocument();
            Document sameDocument = ExampleInstances.TestDocument();
            sameDocument.Id = aDocument.Id;
            Assert.IsTrue(aDocument.Equals(sameDocument));
        }
        [TestMethod]
        public void DocumentEqualsTestDifferentAttr()
        {
            Document aDocument = ExampleInstances.TestDocument();
            Document anotheraDocument = ExampleInstances.TestDocument();
            anotheraDocument.StyleClass = new StyleClass();
            anotheraDocument.Title = "Another Title";
            Assert.IsFalse(aDocument.Equals(anotheraDocument));
        }
        [TestMethod]
        public void ParragraphEqualsTestDifferentID()
        {
            Document aDocument = ExampleInstances.TestDocument();
            Document anotheraDocument = ExampleInstances.TestDocument();
            Assert.IsFalse(aDocument.Equals(anotheraDocument));
        }
        [TestMethod]
        public void DocumentAddParragraphTest()
        {
            Document aDocument = ExampleInstances.TestDocument();
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            aDocument.AddParragraph(aParragraph);
            Assert.IsTrue(aDocument.Parragraphs.Count == 2);
        }
        [TestMethod]
        public void DocumentAddParragraphTestMultiple()
        {
            Document aDocument = ExampleInstances.TestDocument();
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            aDocument.AddParragraph(aParragraph);
            aDocument.AddParragraph(aParragraph);
            aDocument.AddParragraph(aParragraph);
            aDocument.AddParragraph(aParragraph);
            Assert.IsTrue(aDocument.Parragraphs.Count == 5);
        }
    }
}
