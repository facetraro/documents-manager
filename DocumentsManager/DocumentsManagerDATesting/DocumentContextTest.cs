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
        [TestMethod]
        public void AddDocumentTest()
        {
            DocumentContext context = new DocumentContext();
            FormatContext contextFormat = new FormatContext();
            Document newDocument = EntitiesExampleInstances.TestDocument();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
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
            context.Add(newDocument);
            List<Document> allDocumentss = context.GetLazy();
            Assert.IsTrue(allDocumentss.Contains(newDocument));
            TearDown();
        }
        [TestMethod]
        public void RemoveDocumentTest()
        {
            DocumentContext context = new DocumentContext();
            FormatContext contextFormat = new FormatContext();
            Document newDocument = EntitiesExampleInstances.TestDocument();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
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
            context.Add(newDocument);
            context.Remove(newDocument);
            List<Document> allDocumentss = context.GetLazy();
            Assert.IsFalse(allDocumentss.Contains(newDocument));
            TearDown();
        }
    }
}
