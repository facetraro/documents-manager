using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class AdminUserContextTest
    {
  
        [TestMethod]
        public void AddAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = new AdminUser();
            newUser.Id = Guid.NewGuid();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
        }
        [TestMethod]
        public void AddSpecificAdminTest()
        {
            AdminUserContext context = new AdminUserContext();
            AdminUser newUser = new AdminUser();
            newUser.Id = Guid.NewGuid();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Contains(newUser));
        }
    }
}
