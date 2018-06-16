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
    public class EditorBusinessLogicTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public void SetUp()
        {
            TearDown();
            UserContext context = new UserContext();
            User newuser = EntitiesExampleInstances.TestAdminUser();
            newuser.Username = "rareusername";
            newuser.Email = "rareemail";
            context.Add(newuser);
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.LogIn(newuser.Username, newuser.Password);
        }
        [TestMethod]
        public void GetEditorsBLTest() {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            uContext.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors(Guid.NewGuid()).Contains(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetEditorsBLTestSeveral()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            uContext.Add(anEditor);
            uContext.Add(anotherEditor);
            bool expectedResult = true;
            IEnumerable<EditorUser> allEditors = editorBL.GetAllEditors(Guid.NewGuid());
            bool resultOne = allEditors.Contains(anEditor);
            bool resultTwo = allEditors.Contains(anotherEditor);
            Assert.AreEqual(expectedResult, resultOne && resultTwo);
            TearDown();
        }
        [TestMethod]
        public void GetEditorsBLTestEmpty()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors(Guid.NewGuid()).Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddEditorBLTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid expectedResult = editorBL.AddEditor(anEditor, Guid.NewGuid());
            Guid result = uContext.GetById(expectedResult).Id;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddEditorBLTestVerify()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            editorBL.AddEditor(anEditor, Guid.NewGuid());
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors(Guid.NewGuid()).Count() == 1;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }

        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddEditorBLTestExistsEmail()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Email = "differentEmail";
            editorBL.AddEditor(anEditor, Guid.NewGuid());
            editorBL.AddEditor(anotherEditor, Guid.NewGuid());
            TearDown();
        }
        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddEditorBLTestExistsUserName()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Username = "differentUserName";
            editorBL.AddEditor(anEditor, Guid.NewGuid());
            editorBL.AddEditor(anotherEditor, Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorBLTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.AddEditor(anEditor, Guid.NewGuid());
            editorBL.DeleteEditor(idUserToDelete, Guid.NewGuid());
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors(Guid.NewGuid()).Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorBLTestVerify()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.AddEditor(anEditor, Guid.NewGuid());
            editorBL.DeleteEditor(idUserToDelete, Guid.NewGuid());
            bool expectedResult = true;
            bool result = !editorBL.GetAllEditors(Guid.NewGuid()).Contains(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorBLTestMethodResult()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.AddEditor(anEditor, Guid.NewGuid());
            bool expectedResult = true;
            bool result = editorBL.DeleteEditor(idUserToDelete, Guid.NewGuid());
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void DoNotDeleteEditorBLTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            editorBL.DeleteEditor(Guid.NewGuid(), Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdEditorBLTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.AddEditor(anEditor, Guid.NewGuid());
            bool expectedResult = true;
            bool result = editorBL.GetEditorByID(IdUserAdded, Guid.NewGuid()).Equals(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void NoGetByIdEditorBLTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            editorBL.GetEditorByID(Guid.NewGuid(), Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdEditorBLTestWithOthers()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.AddEditor(anEditor, Guid.NewGuid());
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Username = "UserName2";
            anotherEditor.Email = "Email2";
            editorBL.AddEditor(anotherEditor, Guid.NewGuid());
            bool expectedResult = true;
            bool result = editorBL.GetEditorByID(IdUserAdded, Guid.NewGuid()).Equals(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorBLTestOnlyEmail()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.AddEditor(anEditor, Guid.NewGuid());
            anEditor.Email = "modified@gmail.com";
            bool expectedResult = true;
            bool result = editorBL.UpdateEditor(IdUserAdded, anEditor, Guid.NewGuid());
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorBLTestCheckEmail()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.AddEditor(anEditor, Guid.NewGuid());
            anEditor.Email = "modified@gmail.com";
            editorBL.UpdateEditor(IdUserAdded, anEditor, Guid.NewGuid());
            Assert.AreEqual(editorBL.GetEditorByID(IdUserAdded, Guid.NewGuid()).Email, "modified@gmail.com");
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorBLTestCheckAttrs()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.AddEditor(anEditor, Guid.NewGuid());
            anEditor.Name = "George";
            anEditor.Password = "newPassword";
            anEditor.Surname = "Gomez";
            anEditor.Username = "modifiedUsername";
            editorBL.UpdateEditor(IdUserAdded, anEditor, Guid.NewGuid());
            EditorUser modifiedUser = editorBL.GetEditorByID(IdUserAdded, Guid.NewGuid());
            Assert.AreEqual(modifiedUser.Name, "George");
            Assert.AreEqual(modifiedUser.Password, "newPassword");
            Assert.AreEqual(modifiedUser.Surname, "Gomez");
            Assert.AreEqual(modifiedUser.Username, "modifiedUsername");
            Assert.AreEqual(modifiedUser.Id, IdUserAdded);
            TearDown();
        }
        [ExpectedException(typeof(WrongUserType))]
        [TestMethod]
        public void AdminInsteadOfGetByIdEditorBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            editorBL.GetEditorByID(anAdmin.Id, Guid.NewGuid());
            TearDown();
        }

    }
}
