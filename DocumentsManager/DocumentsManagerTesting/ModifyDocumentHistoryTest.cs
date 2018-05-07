using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class ModifyDocumentHistoryTest
    {
        [TestMethod]
        public void ModifyDocumentHistoryBuilder()
        {
            ModifyDocumentHistory newHistroy = new ModifyDocumentHistory();
            Guid newGuid = Guid.NewGuid();
            DateTime newDate = new DateTime();
            User newUser = EntitiesExampleInstances.TestAdminUser();
            Document newDocument = EntitiesExampleInstances.TestDocument();
            newHistroy.Date = newDate;
            newHistroy.Document = newDocument;
            newHistroy.Id = newGuid;
            newHistroy.User = newUser;
            Assert.AreEqual(newHistroy.User, newUser);
            Assert.AreEqual(newHistroy.Document, newDocument);
            Assert.AreEqual(newHistroy.Id, newGuid);
            Assert.AreEqual(newHistroy.Date, newDate);
        }
    }
}
