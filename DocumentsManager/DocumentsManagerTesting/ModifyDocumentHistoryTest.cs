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
            newHistroy.State = ModifyState.Added;
            Assert.AreEqual(newHistroy.User, newUser);
            Assert.AreEqual(newHistroy.Document, newDocument);
            Assert.AreEqual(newHistroy.Id, newGuid);
            Assert.AreEqual(newHistroy.Date, newDate);
            Assert.AreEqual(newHistroy.State, ModifyState.Added);
        }
        [TestMethod]
        public void ModifyDocumentHistoryEqualsFalse()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            ModifyDocumentHistory anotherHistory = new ModifyDocumentHistory();
            Assert.IsFalse(newHistroy.Equals(anotherHistory));
        }
        [TestMethod]
        public void ModifyDocumentHistoryEqualsTrue()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            ModifyDocumentHistory anotherHistory = new ModifyDocumentHistory();
            anotherHistory.Id = newHistroy.Id;
            Assert.IsTrue(newHistroy.Equals(anotherHistory));
        }
        [TestMethod]
        public void ModifyDocumentHistoryEqualsAnotherObject()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            Assert.IsFalse(newHistroy.Equals("aTestString"));
        }
        [TestMethod]
        public void IsFromUserFalse()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            User newUser = EntitiesExampleInstances.TestAdminUser();
            Assert.IsFalse(newHistroy.IsFromUser(newUser));
        }
        [TestMethod]
        public void IsFromUserTrue()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            Assert.IsTrue(newHistroy.IsFromUser(newHistroy.User));
        }
        [TestMethod]
        public void IsOfDocumentFalse()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            Document anotherDocument = EntitiesExampleInstances.TestDocument();
            Assert.IsFalse(newHistroy.IsOfDocument(anotherDocument));
        }
        [TestMethod]
        public void IsOfDocumentTrue()
        {
            ModifyDocumentHistory newHistroy = EntitiesExampleInstances.TestModifyDocumentHistory();
            Assert.IsTrue(newHistroy.IsOfDocument(newHistroy.Document));
        }

    }
}
