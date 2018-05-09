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

    }
}
