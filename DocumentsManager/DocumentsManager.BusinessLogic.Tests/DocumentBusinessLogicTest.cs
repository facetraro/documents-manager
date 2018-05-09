using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;
using DocumentsManager.Data.DA.Handler;
using DocumentsManagerDATesting;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class DocumentBusinessLogicTest
    {
        [TestMethod]
        public void GetDocumentByIdTest()
        {
            DocumentContext contextDocument = new DocumentContext();
            DocumentContextTest testDocument = new DocumentContextTest();
            Document document = testDocument.setUp(contextDocument);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            Document fullDocument = logic.GetDocumentById(document.Id);
            Assert.IsFalse(fullDocument.Footer.Text == null);
            Assert.IsFalse(fullDocument.Footer.StyleClass == null);
            Assert.IsFalse(fullDocument.Header.Text == null);
            Assert.IsFalse(fullDocument.Header.StyleClass == null);
            Assert.IsFalse(fullDocument.Parragraphs[0].StyleClass == null);
            Assert.IsFalse(fullDocument.Parragraphs[0].Texts == null);
            Assert.IsFalse(fullDocument.Format.StyleClasses == null);
        }
    }
}
