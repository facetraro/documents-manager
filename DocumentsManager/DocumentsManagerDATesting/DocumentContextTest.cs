using DocumentsManager.Data.DA.Handler;
using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class DocumentContextTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public Document setUp(DocumentContext context) {
            FormatContext contextFormat = new FormatContext();
            Document newDocument = EntitiesExampleInstances.TestDocument();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            UserContext uContext = new UserContext();
            User creatorUser = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(creatorUser);
            contextsc.Add(style);
            contextsc.Add(newDocument.Footer.StyleClass);
            contextsc.Add(newDocument.Header.StyleClass);
            foreach (var item in newDocument.Format.StyleClasses)
            {
                contextsc.Add(item);
            }
            contextFormat.Add(newDocument.Format);
            foreach (var item in newDocument.Parragraphs)
            {
                contextsc.Add(item.StyleClass);
            }
            newText.StyleClass = style;
            newDocument.StyleClass = style;
            newDocument.Parragraphs.ElementAt(0).Document = newDocument;
            newDocument.CreatorUser = creatorUser;
            newDocument.CreationDate = DateTime.Today;
            context.Add(newDocument);
            return newDocument;
        }
        [TestMethod]
        public void AddDocumentTest()
        {
            DocumentContext context = new DocumentContext();
            Document newDocument = setUp(context);
            List<Document> allDocumentss = context.GetLazy();
            Assert.IsTrue(allDocumentss.Contains(newDocument));
            TearDown();
        }
        [TestMethod]
        public void RemoveDocumentTest()
        {
            DocumentContext context = new DocumentContext();
            Document newDocument = setUp(context);
            context.Remove(newDocument);
            List<Document> allDocumentss = context.GetLazy();
            Assert.IsFalse(allDocumentss.Contains(newDocument));
            TearDown();
        }
        [TestMethod]
        public void RemoveByIdDocumentTest()
        {
            DocumentContext context = new DocumentContext();
            Document newDocument = setUp(context);
            context.Remove(newDocument.Id);
            List<Document> allDocumentss = context.GetLazy();
            Assert.IsFalse(allDocumentss.Contains(newDocument));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveByIdDocumentTest()
         {
            DocumentContext context = new DocumentContext();
            Document newDocument = setUp(context);
            Guid fakeId = Guid.NewGuid();
            context.Remove(fakeId);
            List<Document> allDocumentss = context.GetLazy();
            Assert.IsTrue(allDocumentss.Contains(newDocument));
            TearDown();
        }
        [TestMethod]
        public void ModifyDocumentTest()
        {
            FormatContext formatContext = new FormatContext();
            StyleClassContextHandler scContext = new StyleClassContextHandler();
            UserContext uContext = new UserContext();
            User creatorUser = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(creatorUser);
            DocumentContext context = new DocumentContext();
            Document newDocument = context.GetById(setUp(context).Id);
            Document modifiedDocument = new Document();
            modifiedDocument = modifiedDocument.copyDocument(newDocument);
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            newFooter.Text.WrittenText = "Modified Footer";
            Header newHeader = EntitiesExampleInstances.TestHeader();
            newHeader.Text.WrittenText = "Modified Header";
            modifiedDocument.CreatorUser = creatorUser;
            modifiedDocument.Footer = newFooter;
            modifiedDocument.Header = newHeader;
            scContext.Add(newFooter.StyleClass);
            scContext.Add(newHeader.StyleClass);
            Format newFormat =EntitiesExampleInstances.TestFormat();
            modifiedDocument.Format = newFormat;
            foreach (StyleClass styleClass in newFormat.StyleClasses)
            {
                scContext.Add(styleClass);
            }
            formatContext.Add(modifiedDocument.Format);
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            scContext.Add(newParragraph.StyleClass);
            modifiedDocument.Parragraphs.Add(newParragraph);
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            scContext.Add(newStyle);
            modifiedDocument.StyleClass = newStyle;
            context.Modify(modifiedDocument, newDocument);
            Document dbModDoc = context.GetById(modifiedDocument.Id);
            Assert.AreEqual(dbModDoc.Header,newHeader);
            Assert.AreEqual(dbModDoc.Footer, newFooter);
            Assert.AreEqual(dbModDoc.Parragraphs.Count, modifiedDocument.Parragraphs.Count);
            Assert.AreEqual(dbModDoc.Format, modifiedDocument.Format);
            Assert.AreEqual(dbModDoc.StyleClass, newStyle);
            TearDown();
        }
        [TestMethod]
        public void ModifyDocumentTestSameFormat()
        {
            FormatContext formatContext = new FormatContext();
            StyleClassContextHandler scContext = new StyleClassContextHandler();
            UserContext uContext = new UserContext();
            User creatorUser = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(creatorUser);
            DocumentContext context = new DocumentContext();
            Document newDocument = context.GetById(setUp(context).Id);
            Document modifiedDocument = new Document();
            modifiedDocument = modifiedDocument.copyDocument(newDocument);
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            newFooter.Text.WrittenText = "Modified Footer";
            Header newHeader = EntitiesExampleInstances.TestHeader();
            newHeader.Text.WrittenText = "Modified Header";
            modifiedDocument.CreatorUser = creatorUser;
            modifiedDocument.Footer = newFooter;
            modifiedDocument.Header = newHeader;
            scContext.Add(newFooter.StyleClass);
            scContext.Add(newHeader.StyleClass);
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            scContext.Add(newParragraph.StyleClass);
            modifiedDocument.Parragraphs.Add(newParragraph);
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            scContext.Add(newStyle);
            modifiedDocument.StyleClass = newStyle;
            context.Modify(modifiedDocument, newDocument);
            Document dbModDoc = context.GetById(modifiedDocument.Id);
            Assert.AreEqual(dbModDoc.Header, newHeader);
            Assert.AreEqual(dbModDoc.Footer, newFooter);
            Assert.AreEqual(dbModDoc.Parragraphs.Count, modifiedDocument.Parragraphs.Count);
            Assert.AreEqual(dbModDoc.Format, modifiedDocument.Format);
            Assert.AreEqual(dbModDoc.StyleClass, newStyle);
            TearDown();
        }
    }
   

}
