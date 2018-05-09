using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;
using DocumentsManager.Data.DA.Handler;

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
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            List<User> allUsers = context.GetLazy();
            Assert.IsTrue(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void RemoveSpecificEditorTest()
        {
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Remove(newUser);
            List<User> allUsers = context.GetLazy();
            Assert.IsFalse(allUsers.Contains(newUser));
            TearDown(); 
        }
        [TestMethod]
        public void RemoveSpecificEditorIdTest()
        {
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Remove(newUser.Id);
            List<User> allUsers = context.GetLazy();
            Assert.IsFalse(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveSpecificEditorTest()
        {
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Remove(Guid.NewGuid());
            List<User> allUsers = context.GetLazy();
            Assert.IsTrue(allUsers.Contains(newUser));
            TearDown();
        }

        [TestMethod]
        public void ModifyEditorTest()
        {
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            newUser.Email = "newEmail";
            newUser.Name = "newName";
            context.Modify(newUser);
            List<User> allUsers = context.GetLazy();
            Assert.IsTrue(allUsers.Contains(newUser));
            Assert.IsTrue(allUsers.Find(item => item.Id == newUser.Id).Email == newUser.Email);
            Assert.IsTrue(allUsers.Find(item => item.Id == newUser.Id).Name == newUser.Name);
            TearDown();
        }
        [TestMethod]
        public void GetEditorsTestZero()
        {
            UserContext context = new UserContext();
            List<EditorUser> allEditors = context.GetEditors();
            Assert.IsTrue(allEditors.Count == 0);
            TearDown();
        }
        [TestMethod]
        public void GetEditorsTestOne()
        {
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            List<EditorUser> allEditors = context.GetEditors();
            Assert.IsTrue(allEditors.Count==1);
            Assert.IsTrue(allEditors.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void GetEditorsTestTwo()
        {
            UserContext context = new UserContext();
            EditorUser newUser = EntitiesExampleInstances.TestEditorUser();
            EditorUser anotherUser = EntitiesExampleInstances.TestEditorUser();
            context.Add(newUser);
            context.Add(anotherUser);
            List<EditorUser> allEditors = context.GetEditors();
            Assert.IsTrue(allEditors.Count == 2);
            Assert.IsTrue(allEditors.Contains(newUser));
            Assert.IsTrue(allEditors.Contains(anotherUser));
            TearDown();
        }
    }
}
