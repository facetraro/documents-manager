using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class EditorUserContextTest
    {
        public void TearDown()
        {
            ClearEditorDataBase();
        }
        private void ClearEditorDataBase()
        {
            EditorUserContext context = new EditorUserContext();
            context.ClearAll();
        }
        [TestMethod]
        public void AddEditorTest()
        {
            EditorUserContext context = new EditorUserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            List<EditorUser> allEditors = context.GetLazy();
            Assert.IsTrue(allEditors.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void RemoveSpecificEditorTest()
        {
            EditorUserContext context = new EditorUserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Remove(newUser);
            List<EditorUser> allEditors = context.GetLazy();
            Assert.IsFalse(allEditors.Contains(newUser));
            TearDown(); 
        }
    }
}
