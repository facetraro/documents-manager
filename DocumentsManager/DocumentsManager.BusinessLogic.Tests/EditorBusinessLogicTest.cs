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
        }
        [TestMethod]
        public void GetEditorsTest() {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            uContext.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors().Contains(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetEditorsTestSeveral()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            uContext.Add(anEditor);
            uContext.Add(anotherEditor);
            bool expectedResult = true;
            IEnumerable<EditorUser> allEditors = editorBL.GetAllEditors();
            bool resultOne = allEditors.Contains(anEditor);
            bool resultTwo = allEditors.Contains(anotherEditor);
            Assert.AreEqual(expectedResult, resultOne && resultTwo);
            TearDown();
        }
        [TestMethod]
        public void GetEditorsTestEmpty()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddEditorTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid expectedResult = editorBL.Add(anEditor);
            Guid result = uContext.GetById(expectedResult).Id;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddEditorTestVerify()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            editorBL.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors().Count() == 1;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }

        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddEditorTestExistsEmail()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Email = "differentEmail";
            editorBL.Add(anEditor);
            editorBL.Add(anotherEditor);
            TearDown();
        }
        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddEditorTestExistsUserName()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Username = "differentUserName";
            editorBL.Add(anEditor);
            editorBL.Add(anotherEditor);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.Add(anEditor);
            editorBL.Delete(idUserToDelete);
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorTestVerify()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.Add(anEditor);
            editorBL.Delete(idUserToDelete);
            bool expectedResult = true;
            bool result = !editorBL.GetAllEditors().Contains(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorTestMethodResult()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.Delete(idUserToDelete);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void DoNotDeleteEditorTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            editorBL.Delete(Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdEditorTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.GetByID(IdUserAdded).Equals(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void NoGetByIdEditorTest()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            editorBL.GetByID(Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdEditorTestWithOthers()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Username = "UserName2";
            anotherEditor.Email = "Email2";
            editorBL.Add(anotherEditor);
            bool expectedResult = true;
            bool result = editorBL.GetByID(IdUserAdded).Equals(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorTestOnlyEmail()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            anEditor.Email = "modified@gmail.com";
            bool expectedResult = true;
            bool result = editorBL.Update(IdUserAdded, anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorTestCheckEmail()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            anEditor.Email = "modified@gmail.com";
            editorBL.Update(IdUserAdded, anEditor);
            Assert.AreEqual(editorBL.GetByID(IdUserAdded).Email, "modified@gmail.com");
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorTestCheckAttrs()
        {
            SetUp();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            anEditor.Name = "George";
            anEditor.Password = "newPassword";
            anEditor.Surname = "Gomez";
            anEditor.Username = "modifiedUsername";
            editorBL.Update(IdUserAdded, anEditor);
            EditorUser modifiedUser = editorBL.GetByID(IdUserAdded);
            Assert.AreEqual(modifiedUser.Name, "George");
            Assert.AreEqual(modifiedUser.Password, "newPassword");
            Assert.AreEqual(modifiedUser.Surname, "Gomez");
            Assert.AreEqual(modifiedUser.Username, "modifiedUsername");
            Assert.AreEqual(modifiedUser.Id, IdUserAdded);
            TearDown();
        }
        [ExpectedException(typeof(WrongUserType))]
        [TestMethod]
        public void AdminInsteadOfGetByIdEditorTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.Add(anAdmin);
            editorBL.GetByID(anAdmin.Id);
            TearDown();
        }

    }
}
