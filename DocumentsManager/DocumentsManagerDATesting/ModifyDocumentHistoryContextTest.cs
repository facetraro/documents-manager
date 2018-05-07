using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;
using DocumentsManager.Data.DA.Handler;
using System.Linq;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class ModifyDocumentHistoryContextTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        [TestMethod]
        public void AddModifyDocumentHistoryTest()
        {
            ModifyDocumentHistory newHistory = EntitiesExampleInstances.TestModifyDocumentHistory();
            UserContext contextUser = new UserContext();
            contextUser.Add(newHistory.User);
            DocumentContext dContext = new DocumentContext();
            DocumentContextTest documentTest = new DocumentContextTest();
            newHistory.Document = documentTest.setUp(dContext);
            ModifyDocumentHistoryContext context = new ModifyDocumentHistoryContext();
            context.Add(newHistory);
            List<ModifyDocumentHistory> allHistories = context.GetAllHistories();
            Assert.IsTrue(allHistories.Contains(newHistory));
            TearDown();
        }
        [TestMethod]
        public void RemoveModifyDocumentHistoryTest()
        {
            ModifyDocumentHistory newHistory = EntitiesExampleInstances.TestModifyDocumentHistory();
            UserContext contextUser = new UserContext();
            contextUser.Add(newHistory.User);
            DocumentContext dContext = new DocumentContext();
            DocumentContextTest documentTest = new DocumentContextTest();
            newHistory.Document = documentTest.setUp(dContext);
            ModifyDocumentHistoryContext context = new ModifyDocumentHistoryContext();
            context.Add(newHistory);
            context.Remove(newHistory);
            List<ModifyDocumentHistory> allHistories = context.GetAllHistories();
            Assert.IsTrue(allHistories.Count==0);
            TearDown();
        }
        [TestMethod]
        public void GetModifyDocumentHistoryTest()
        {
            ModifyDocumentHistory newHistory = EntitiesExampleInstances.TestModifyDocumentHistory();
            UserContext contextUser = new UserContext();
            contextUser.Add(newHistory.User);
            DocumentContext dContext = new DocumentContext();
            DocumentContextTest documentTest = new DocumentContextTest();
            newHistory.Document = documentTest.setUp(dContext);
            ModifyDocumentHistoryContext context = new ModifyDocumentHistoryContext();
            context.Add(newHistory);
            ModifyDocumentHistory result = context.GetById(newHistory.Id);
            Assert.AreEqual(result.User, newHistory.User);
            Assert.AreEqual(result.Document, newHistory.Document);
            Assert.AreEqual(result.Id, newHistory.Id);
            TearDown();
        }
        [TestMethod]
        public void GetAllHistoriesTest()
        {
            ModifyDocumentHistory newHistory = EntitiesExampleInstances.TestModifyDocumentHistory();
            UserContext contextUser = new UserContext();
            contextUser.Add(newHistory.User);
            DocumentContext dContext = new DocumentContext();
            DocumentContextTest documentTest = new DocumentContextTest();
            newHistory.Document = documentTest.setUp(dContext);
            ModifyDocumentHistoryContext context = new ModifyDocumentHistoryContext();
            context.Add(newHistory);
            List<ModifyDocumentHistory> allHistories = context.GetAllHistories();
            Assert.IsTrue(allHistories.Contains(newHistory));
            Assert.AreEqual(allHistories.ElementAt(0).User, newHistory.User);
            Assert.AreEqual(allHistories.ElementAt(0).Document, newHistory.Document);
            Assert.AreEqual(allHistories.ElementAt(0).Id, newHistory.Id);
            TearDown();
        }
    }
}
