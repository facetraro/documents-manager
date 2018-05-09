using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManagerDATesting;
using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class AdminBusinessLogicTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public void SetUp()
        {
            TearDown();
        }
        [TestMethod]
        public void GetAdminsTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Contains(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsTestSeveral()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            uContext.Add(anotherAdmin);
            bool expectedResult = true;
            IEnumerable<AdminUser> allAdmins = adminBL.GetAllAdmins();
            bool resultOne = allAdmins.Contains(anAdmin);
            bool resultTwo = allAdmins.Contains(anotherAdmin);
            Assert.AreEqual(expectedResult, resultOne && resultTwo);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsTestEmpty()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddAdminTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid expectedResult = adminBL.Add(anAdmin);
            Guid result = uContext.GetById(expectedResult).Id;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddAdminTestVerify()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            adminBL.Add(anAdmin);
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Count() == 1;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        
        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddAdminTestExistsEmail()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            anotherAdmin.Email = "differentEmail";
            adminBL.Add(anAdmin);
            adminBL.Add(anotherAdmin);
            TearDown();
        }
        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddAdminTestExistsUserName()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            anotherAdmin.Username = "differentUserName";
            adminBL.Add(anAdmin);
            adminBL.Add(anotherAdmin);
            TearDown();
        }
        [TestMethod]
        public void DeleteAdminTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid idUserToDelete = adminBL.Add(anAdmin);
            adminBL.Delete(idUserToDelete);
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorTestVerify()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid idUserToDelete = adminBL.Add(anAdmin);
            adminBL.Delete(idUserToDelete);
            bool expectedResult = true;
            bool result = !adminBL.GetAllAdmins().Contains(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorTestMethodResult()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid idUserToDelete = adminBL.Add(anAdmin);
            bool expectedResult = true;
            bool result = adminBL.Delete(idUserToDelete);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void DoNotDeleteEditorTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.Delete(Guid.NewGuid());
            TearDown();
        }
    }
}
