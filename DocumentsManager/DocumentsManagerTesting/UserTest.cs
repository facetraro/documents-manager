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
        [TestMethod]
        public void TestUserValidWrong()
        {
            User user = new AdminUser {
                Name = "",
                Username = "",
                Password = "",
                Email = ""
            };
            Assert.IsFalse(user.isUserValid());
        }
        [TestMethod]
        public void TestUserValidWrongEmail()
        {
            User user = new AdminUser
            {
                Name = "AAA",
                Username = "AAA",
                Password = "AAAAAA",
                Email = "@@@@"
            };
            Assert.IsFalse(user.isUserValid());
        }
        [TestMethod]
        public void TestUserValidWrongName()
        {
            User user = new AdminUser
            {
                Name = "",
                Username = "AAA",
                Password = "AAAAAA",
                Email = "AAAA@AAAA"
            };
            Assert.IsFalse(user.isUserValid());
        }
        [TestMethod]
        public void TestUserValidWrongUserName()
        {
            User user = new AdminUser
            {
                Name = "AAA",
                Username = "",
                Password = "AAAAAA",
                Email = "AAAA@AAAA"
            };
            Assert.IsFalse(user.isUserValid());
        }
        [TestMethod]
        public void TestUserValidWrongPassword()
        {
            User user = new AdminUser
            {
                Name = "AAA",
                Username = "AAAAAA",
                Password = "",
                Email = "AAAA@AAAA"
            };
            Assert.IsFalse(user.isUserValid());
        }
        [TestMethod]
        public void TestUserValidWrongShortEmail()
        {
            User user = new AdminUser
            {
                Name = "AAA",
                Username = "AAAAAA",
                Password = "",
                Email = "A@A"
            };
            Assert.IsFalse(user.isUserValid());
        }
        [TestMethod]
        public void TestUserValid()
        {
            User user = new AdminUser
            {
                Name = "AAAA",
                Username = "AAAAAA",
                Password = "AAAA",
                Email = "AAAA@AAAA"
            };
            Assert.IsTrue(user.isUserValid());
        }
    }
}
