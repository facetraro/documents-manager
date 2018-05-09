using DocumentsManagerExampleInstances;
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
            Format aFormat = EntitiesExampleInstances.TestFormat();
            Header aHeader = EntitiesExampleInstances.TestHeader();
            Footer aFooter = EntitiesExampleInstances.TestFooter();
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(EntitiesExampleInstances.TestParragraph());
            parragraphs.Add(EntitiesExampleInstances.TestParragraph());
            User anUser = EntitiesExampleInstances.TestUser();
            StyleClass aStyle = EntitiesExampleInstances.TestStyleClass();
            DateTime aDate = DateTime.Today;
            string title = "This is a Title";
            aDocument.Id = id;
            aDocument.Format = aFormat;
            aDocument.Header = aHeader;
            aDocument.Footer = aFooter;
            aDocument.Parragraphs = parragraphs;
            aDocument.StyleClass = aStyle;
            aDocument.Title = title;
            Assert.AreEqual(aDocument.Id,id);
            Assert.AreEqual(aDocument.Format,aFormat);
            Assert.AreEqual(aDocument.Header,aHeader);
            Assert.AreEqual(aDocument.Footer,aFooter);
            Assert.AreEqual(aDocument.Parragraphs,parragraphs);
            Assert.AreEqual(aDocument.StyleClass,aStyle);
            Assert.AreEqual(aDocument.Title, title);
        }
        [TestMethod]
        public void DocumentBuilderTestDifferentAttr()
        {
            Document aDocument = new Document();
            Guid id = Guid.NewGuid();
            Format aFormat = EntitiesExampleInstances.TestFormat();
            Header aHeader = EntitiesExampleInstances.TestHeader();
            Footer aFooter = EntitiesExampleInstances.TestFooter();
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(EntitiesExampleInstances.TestParragraph());
            parragraphs.Add(EntitiesExampleInstances.TestParragraph());
            User anUser = EntitiesExampleInstances.TestUser();
            StyleClass aStyle = EntitiesExampleInstances.TestStyleClass();
            DateTime aDate = DateTime.Today;
            string title = "This is a Title";
            aDocument.Id = id;
            aDocument.Format = aFormat;
            aDocument.Header = aHeader;
            aDocument.Footer = aFooter;
            aDocument.Parragraphs = parragraphs;
            aDocument.StyleClass = aStyle;
            aDocument.Title = title;
            Assert.AreNotEqual(aDocument.Id, Guid.NewGuid());
            Assert.AreNotEqual(aDocument.Format, EntitiesExampleInstances.TestFormat());
            Assert.AreNotEqual(aDocument.Header, EntitiesExampleInstances.TestHeader());
            Assert.AreNotEqual(aDocument.Footer, EntitiesExampleInstances.TestFooter());
            Assert.AreNotEqual(aDocument.Parragraphs, new List<Parragraph>());
            Assert.AreNotEqual(aDocument.StyleClass, EntitiesExampleInstances.TestStyleClass());
            Assert.AreNotEqual(aDocument.Title, "");
        }
        [TestMethod]
        public void DocumentEqualsTestSameAttr()
        {
            Document aDocument = EntitiesExampleInstances.TestDocument();
            Document sameDocument = EntitiesExampleInstances.TestDocument();
            sameDocument.Id = aDocument.Id;
            Assert.IsTrue(aDocument.Equals(sameDocument));
        }
        [TestMethod]
        public void DocumentEqualsTestDifferentAttr()
        {
            Document aDocument = EntitiesExampleInstances.TestDocument();
            Document anotheraDocument = EntitiesExampleInstances.TestDocument();
            anotheraDocument.StyleClass = new StyleClass();
            anotheraDocument.Title = "Another Title";
            Assert.IsFalse(aDocument.Equals(anotheraDocument));
        }
        [TestMethod]
        public void ParragraphEqualsTestDifferentID()
        {
            Document aDocument = EntitiesExampleInstances.TestDocument();
            Document anotheraDocument = EntitiesExampleInstances.TestDocument();
            Assert.IsFalse(aDocument.Equals(anotheraDocument));
        }
        [TestMethod]
        public void DocumentAddParragraphTest()
        {
            Document aDocument = EntitiesExampleInstances.TestDocument();
            Parragraph aParragraph = EntitiesExampleInstances.TestParragraph();
            aDocument.AddParragraph(aParragraph);
            Assert.IsTrue(aDocument.Parragraphs.Count == 2);
        }
        [TestMethod]
        public void DocumentAddParragraphTestMultiple()
        {
            Document aDocument = EntitiesExampleInstances.TestDocument();
            Parragraph aParragraph = EntitiesExampleInstances.TestParragraph();
            aDocument.AddParragraph(aParragraph);
            aDocument.AddParragraph(aParragraph);
            aDocument.AddParragraph(aParragraph);
            aDocument.AddParragraph(aParragraph);
            Assert.IsTrue(aDocument.Parragraphs.Count == 5);
        }
    }
}
