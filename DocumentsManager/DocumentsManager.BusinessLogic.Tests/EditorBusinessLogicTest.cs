using DocumentsManager.Data.DA.Handler;
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
        [TestMethod]
        public void GetEditorsTest() {
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
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddEditorTest()
        {
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
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            editorBL.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.GetAllEditors().Count() == 1;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteEditorTest()
        {
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
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid idUserToDelete = editorBL.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.Delete(idUserToDelete);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DoNotDeleteEditorTest()
        {
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            bool expectedResult = false;
            bool result = editorBL.Delete(Guid.NewGuid());
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetByIdEditorTest()
        {
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            bool expectedResult = true;
            bool result = editorBL.GetByID(IdUserAdded).Equals(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetByIdEditorTestWithOthers()
        {
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.Add(anEditor);
            editorBL.Add(EntitiesExampleInstances.TestEditorUser());
            bool expectedResult = true;
            bool result = editorBL.GetByID(IdUserAdded).Equals(anEditor);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateEditorTestOnlyEmail()
        {
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

    }
}
