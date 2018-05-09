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
        public void GetAdminsBLTest()
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
        public void GetAdminsBLTestSeveral()
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
        public void GetAdminsBLTestEmpty()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddAdminBLTBLest()
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
        public void AddAdminBLTestVerify()
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
        public void AddAdminBLTestExistsEmail()
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
        public void AddAdminBLTestExistsUserName()
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
        public void DeleteAdminBLTest()
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
        public void DeleteAdminBLTestVerify()
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
        public void DeleteAdminBLTestMethodResult()
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
        public void DoNotDeleteAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.Delete(Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.Add(anAdmin);
            bool expectedResult = true;
            bool result = adminBL.GetByID(IdUserAdded).Equals(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void NoGetByIdAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.GetByID(Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdAdminBLTestWithOthers()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.Add(anAdmin);
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            anotherAdmin.Username = "UserName2";
            anotherAdmin.Email = "Email2";
            adminBL.Add(anotherAdmin);
            bool expectedResult = true;
            bool result = adminBL.GetByID(IdUserAdded).Equals(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(WrongUserType))]
        [TestMethod]
        public void EditorInsteadOfGetByIdAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            adminBL.GetByID(anEditor.Id);
            TearDown();
        }
        [TestMethod]
        public void UpdateAdminBLTestOnlyEmail()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.Add(anAdmin);
            anAdmin.Email = "modified@gmail.com";
            bool expectedResult = true;
            bool result = adminBL.Update(IdUserAdded, anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateAdminBLTestCheckEmail()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.Add(anAdmin);
            anAdmin.Email = "modified@gmail.com";
            adminBL.Update(IdUserAdded, anAdmin);
            Assert.AreEqual(adminBL.GetByID(IdUserAdded).Email, "modified@gmail.com");
            TearDown();
        }
        [TestMethod]
        public void UpdateAdminBLTestCheckAttrs()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.Add(anAdmin);
            anAdmin.Name = "George";
            anAdmin.Password = "newPassword";
            anAdmin.Surname = "Gomez";
            anAdmin.Username = "modifiedUsername";
            adminBL.Update(IdUserAdded, anAdmin);
            AdminUser modifiedUser = adminBL.GetByID(IdUserAdded);
            Assert.AreEqual(modifiedUser.Name, "George");
            Assert.AreEqual(modifiedUser.Password, "newPassword");
            Assert.AreEqual(modifiedUser.Surname, "Gomez");
            Assert.AreEqual(modifiedUser.Username, "modifiedUsername");
            Assert.AreEqual(modifiedUser.Id, IdUserAdded);
            TearDown();
        }
    }
}
