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
            ClearAdminDataBase();
        }
        private void ClearAdminDataBase()
        {
            AdminUserContext context = new AdminUserContext();
            context.ClearAll();
        }
        [TestMethod]
        public void AddAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void AddSpecificAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void RemoveSpecificAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            context.Remove(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsFalse(allAdmins.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void RemoveSpecificAdminIdTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            context.Remove(newUser.Id);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsFalse(allAdmins.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveSpecificAdminIdTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            context.Remove(Guid.NewGuid());
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
            TearDown();
        }
        [TestMethod]
        public void ModifyAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            newUser.Email = "newEmail";
            newUser.Name = "newName";
            context.Modify(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
            Assert.IsTrue(allAdmins.Find(item => item.Id == newUser.Id).Email == newUser.Email);
            Assert.IsTrue(allAdmins.Find(item => item.Id == newUser.Id).Name == newUser.Name);
            TearDown();
        }
    }
}
