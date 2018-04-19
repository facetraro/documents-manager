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
        User TestUser()
        {
            User user = new AdminUser();
            user.Id = Guid.NewGuid();
            user.Username = "DefaultUsername";
            user.Password = "DefaultPassword";
            user.Name = "DefaultName";
            user.Surname = "DefaultSurname";
            user.Email = "DefaultEmail@DefaultEmail.com";
            return user;
        }
        [TestMethod]
        public void TestUserSameUserByEmail()
        {
            User user = TestUser();
            Assert.IsTrue(user.IsSameUserByEmail(user));
        }
        [TestMethod]
        public void TestUserNotSameUserByEmail()
        {
            User user = TestUser();
            User user2 = TestUser();
            user2.Email = "NewEmail";
            Assert.IsFalse(user.IsSameUserByEmail(user2));
        }
        [TestMethod]
        public void TestUserSameUserByOnlyEmail()
        {   User user = TestUser();
            User user2 = TestUser();
            user.Username = "DifferentAttribute";
            user.Password = "DifferentAttribute";
            user.Name = "DifferentAttribute";
            user.Surname = "DifferentAttribute";
            Assert.IsTrue(user.IsSameUserByEmail(user));
        }
        [TestMethod]
        public void TestUserSameUserByUsername()
        {
            User user = TestUser();
            Assert.IsTrue(user.IsSameUserByUsername(user));
        }
        [TestMethod]
        public void TestUserNotSameUserByUsername()
        {
            User user = TestUser();
            User user2 = TestUser();
            user2.Username = "Different Username";
            Assert.IsFalse(user.IsSameUserByUsername(user2));
        }
        [TestMethod]
        public void TestUserOnlySameUserByUsername()
        {
            User user = TestUser();
            User user2 = TestUser();
            user2.Name = "Different Name";
            user2.Surname = "Different Surname";
            user2.Password = "Different Password";
            user2.Email = "Different Email";
            Assert.IsTrue(user.IsSameUserByUsername(user2));
        }
    }
}
