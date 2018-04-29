using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class AdminUserContextTest
    {
  
        [TestMethod]
        public void AddAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
        }
        [TestMethod]
        public void AddSpecificAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
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
        }
    }
}
