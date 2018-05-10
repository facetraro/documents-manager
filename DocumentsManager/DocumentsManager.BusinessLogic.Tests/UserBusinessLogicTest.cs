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
            ClearDataBase.ClearAll();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            Document newDocument = EntitiesExampleInstances.TestDocumentWithOneStyle();
            Guid idNewTestAdmin = adminLogic.Add(newAdmin);
            newAdmin.Id = idNewTestAdmin;
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            styleClassLogic.Add(newDocument.StyleClass);
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            formatLogic.Add(newDocument.Format);
            Guid id = logic.AddDocument(newAdmin, newDocument);
            newDocument.Id = id;
            Assert.IsTrue(documentLogic.GetDocumentById(id).Equals(newDocument));
            ClearDataBase.ClearAll();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void AddDocumentTestWithoutStyle()
        {
            ClearDataBase.ClearAll();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            Document newDocument = EntitiesExampleInstances.TestDocumentWithOneStyle();
            Guid idNewTestAdmin = adminLogic.Add(newAdmin);
            newAdmin.Id = idNewTestAdmin;
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            styleClassLogic.Add(newDocument.StyleClass);
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            formatLogic.Add(newDocument.Format);
            newDocument.StyleClass = EntitiesExampleInstances.TestStyleClass();
            Guid id = logic.AddDocument(newAdmin, newDocument);
            ClearDataBase.ClearAll();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void AddDocumentTestWithoutFormat()
        {
            ClearDataBase.ClearAll();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            Document newDocument = EntitiesExampleInstances.TestDocumentWithOneStyle();
            Guid idNewTestAdmin = adminLogic.Add(newAdmin);
            newAdmin.Id = idNewTestAdmin;
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            styleClassLogic.Add(newDocument.StyleClass);
            Guid id = logic.AddDocument(newAdmin, newDocument);
            ClearDataBase.ClearAll();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void AddDocumentTestWithoutUser()
        {
            ClearDataBase.ClearAll();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            Document newDocument = EntitiesExampleInstances.TestDocumentWithOneStyle();
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            styleClassLogic.Add(newDocument.StyleClass);
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            formatLogic.Add(newDocument.Format);
            Guid id = logic.AddDocument(newAdmin, newDocument);
            ClearDataBase.ClearAll();
        }
    }
}