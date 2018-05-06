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
    public class AdminUserContextTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        [TestMethod]
        public void AddAdminTest()
        {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            List<User> allUsers = context.GetLazy();
            Assert.IsTrue(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void AddSpecificAdminTest()
        {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            List<User> allUsers = context.GetLazy();
            Assert.IsTrue(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void RemoveSpecificAdminTest()
        {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            context.Remove(newUser);
            List<User> allUsers = context.GetLazy();
            Assert.IsFalse(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void RemoveSpecificAdminIdTest()
        {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            context.Remove(newUser.Id);
            List<User> allUsers = context.GetLazy();
            Assert.IsFalse(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveSpecificAdminIdTest()
        {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            context.Remove(Guid.NewGuid());
            List<User> allUsers = context.GetLazy();
            Assert.IsTrue(allUsers.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void ModifyAdminTest()
        {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
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
    }
}
