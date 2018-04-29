using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerTesting
{
    [TestClass]
   public class AdminUserTest
    {
       

        [TestMethod]
        public void EditorUserBuilderTestSameAttributes()
        {
            string DefaultUsername = "DefaultUsername";
            string DefaultPassword = "DefaultPassword";
            string DefaultName = "DefaultName";
            string DefaultSurname = "DefaultSurname";
            string DefaultEmail = "DefaultEmail@DefaultEmail.com";
            AdminUser user = EntitiesExampleInstances.TestAdminUser();
            Assert.AreEqual(user.Username, DefaultUsername);
            Assert.AreEqual(user.Password, DefaultPassword);
            Assert.AreEqual(user.Name, DefaultName);
            Assert.AreEqual(user.Surname, DefaultSurname);
            Assert.AreEqual(user.Email, DefaultEmail);
        }
        [TestMethod]
        public void EditorUserBuilderTestDifferentAttributes()
        {
            AdminUser user = EntitiesExampleInstances.TestAdminUser();
            Assert.AreNotEqual(user.Username, "DefaultUsername2");
            Assert.AreNotEqual(user.Password, "DefaultUsername2");
            Assert.AreNotEqual(user.Name, "DefaultName2");
            Assert.AreNotEqual(user.Surname, "DefaultSurname2");
            Assert.AreNotEqual(user.Email, "DefaultEmail@DefaultEmail.com2");
        }
        [TestMethod]
        public void AdminUserEqualsTest()
        {
            AdminUser user = EntitiesExampleInstances.TestAdminUser();
            Assert.IsTrue(user.Equals(user));
        }
        [TestMethod]
        public void AdminUserNotEqualsTest()
        {
            AdminUser user = EntitiesExampleInstances.TestAdminUser();
            AdminUser user2 = EntitiesExampleInstances.TestAdminUser();
            Assert.IsFalse(user.Equals(user2));
        }
        [TestMethod]
        public void AdminUserNotUserEqualsTest()
        {
            AdminUser user = EntitiesExampleInstances.TestAdminUser();
            string otherObject = "NotAnUser";
            Assert.IsFalse(user.Equals(otherObject));
        }
    }
}
