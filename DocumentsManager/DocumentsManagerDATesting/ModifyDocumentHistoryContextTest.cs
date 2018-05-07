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
        }
    }
}
