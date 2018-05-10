using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;
using DocumentsManagerDATesting;
using DocumentsManager.Data.DA.Handler;
using DocumentsManagerExampleInstances;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        [TestMethod]
        public void AddDocumentTestOk()
        {
            SetUp();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            Document newDocument = SetUpDocument();
            AdminUser newAdmin = SetUpAdminInDB();
            Guid id = logic.AddDocument(newAdmin, newDocument);
            newDocument.Id = id;
            Assert.IsTrue(documentLogic.GetDocumentById(id).Equals(newDocument));
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void AddDocumentTestWithoutStyle()
        {
            SetUp();
            UserBusinessLogic logic = new UserBusinessLogic();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Document newDocument = SetUpDocument();
            AdminUser newAdmin = SetUpAdminInDB();
            newDocument.StyleClass = EntitiesExampleInstances.TestStyleClass();
            Guid id = logic.AddDocument(newAdmin, newDocument);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void AddDocumentTestWithoutFormat()
        {
            SetUp();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            Document newDocument = SetUpDocument();
            AdminUser newAdmin = SetUpAdminInDB();
            newDocument.Format = EntitiesExampleInstances.TestFormat();
            Guid id = logic.AddDocument(newAdmin, newDocument);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void AddDocumentTestWithoutUser()
        {
            SetUp();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            Document newDocument = SetUpDocument();
            Guid id = logic.AddDocument(EntitiesExampleInstances.TestAdminUser(), newDocument);
            TearDown();
        }
        private void SetUp()
        {
            ClearDataBase.ClearAll();
        }
        private Document SetUpDocument()
        {
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Document newDocument = EntitiesExampleInstances.TestDocumentWithOneStyle();
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            styleClassLogic.Add(newDocument.StyleClass);
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            formatLogic.Add(newDocument.Format);
            return newDocument;
        }
        private AdminUser SetUpAdminInDB()
        {
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid idNewTestAdmin = adminLogic.Add(newAdmin);
            newAdmin.Id = idNewTestAdmin;
            return newAdmin;
        }
        private void TearDown()
        {
            ClearDataBase.ClearAll();
        }
    }
}