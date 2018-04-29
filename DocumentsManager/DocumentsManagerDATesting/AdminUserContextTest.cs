using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class AdminUserContextTest
    {
        [TestMethod]
        public void AddAdminTest()
        {
            AdminUser newUser = new AdminUser();
            ContextDataAccess context = new ContextDataAccess();
            context.Add(newUser);
            List<AdminUser> allAdmins = context.GetLazy();
            Assert.IsTrue(allAdmins.Count==1);
        }
    }
}
