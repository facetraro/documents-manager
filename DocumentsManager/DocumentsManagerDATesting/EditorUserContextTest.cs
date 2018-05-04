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
            ClearDataBase.ClearAll();
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
        [TestMethod]
        public void RemoveSpecificEditorIdTest()
        {
            EditorUserContext context = new EditorUserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Remove(newUser.Id);
            List<EditorUser> allEditors = context.GetLazy();
            Assert.IsFalse(allEditors.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveSpecificEditorTest()
        {
            EditorUserContext context = new EditorUserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Remove(Guid.NewGuid());
            List<EditorUser> allEditors = context.GetLazy();
            Assert.IsTrue(allEditors.Contains(newUser));
            TearDown();
        }

        [TestMethod]
        public void ModifyEditorTest()
        {
            EditorUserContext context = new EditorUserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            newUser.Email = "newEmail";
            newUser.Name = "newName";
            context.Modify(newUser);
            List<EditorUser> allEditors = context.GetLazy();
            Assert.IsTrue(allEditors.Contains(newUser));
            Assert.IsTrue(allEditors.Find(item => item.Id == newUser.Id).Email == newUser.Email);
            Assert.IsTrue(allEditors.Find(item => item.Id == newUser.Id).Name == newUser.Name);
            TearDown();
        }
    }
}
