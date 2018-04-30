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
    public class UserTest
    {
        
        [TestMethod]
        public void TestUserSameUserByEmail()
        {
            User user = EntitiesExampleInstances.TestUser();
            Assert.IsTrue(user.IsSameUserByEmail(user));
        }
        [TestMethod]
        public void TestUserNotSameUserByEmail()
        {
            User user = EntitiesExampleInstances.TestUser();
            User user2 = EntitiesExampleInstances.TestUser();
            user2.Email = "NewEmail";
            Assert.IsFalse(user.IsSameUserByEmail(user2));
        }
        [TestMethod]
        public void TestUserSameUserByOnlyEmail()
        {   User user = EntitiesExampleInstances.TestUser();
            User user2 = EntitiesExampleInstances.TestUser();
            user.Username = "DifferentAttribute";
            user.Password = "DifferentAttribute";
            user.Name = "DifferentAttribute";
            user.Surname = "DifferentAttribute";
            Assert.IsTrue(user.IsSameUserByEmail(user));
        }
        [TestMethod]
        public void TestUserSameUserByUsername()
        {
            User user = EntitiesExampleInstances.TestUser();
            Assert.IsTrue(user.IsSameUserByUsername(user));
        }
        [TestMethod]
        public void TestUserNotSameUserByUsername()
        {
            User user = EntitiesExampleInstances.TestUser();
            User user2 = EntitiesExampleInstances.TestUser();
            user2.Username = "Different Username";
            Assert.IsFalse(user.IsSameUserByUsername(user2));
        }
        [TestMethod]
        public void TestUserOnlySameUserByUsername()
        {
            User user = EntitiesExampleInstances.TestUser();
            User user2 = EntitiesExampleInstances.TestUser();
            user2.Name = "Different Name";
            user2.Surname = "Different Surname";
            user2.Password = "Different Password";
            user2.Email = "Different Email";
            Assert.IsTrue(user.IsSameUserByUsername(user2));
        }

        [TestMethod]
        public void TestUserAuthenticate() {
            User user = EntitiesExampleInstances.TestUser();
            Assert.IsTrue(user.Authenticate(user.Password));
        }
        [TestMethod]
        public void TestUserAuthenticateFalse() {
            User user = EntitiesExampleInstances.TestUser();
            Assert.IsFalse(user.Authenticate("NotThePassword"));
        }
    }
}
