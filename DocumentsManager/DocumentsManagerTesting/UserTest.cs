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
        public void UserSameUserByEmail()
        {
            string DefaultUsername = "DefaultUsername";
            string DefaultPassword = "DefaultPassword";
            string DefaultName = "DefaultName";
            string DefaultSurname = "DefaultSurname";
            string DefaultEmail = "DefaultEmail@DefaultEmail.com";
            AdminUser user = new AdminUser();
            user.Username = DefaultUsername;
            user.Password = DefaultPassword;
            user.Name = DefaultName;
            user.Surname = DefaultSurname;
            user.Email = DefaultEmail;
            Assert.IsTrue(user.IsSameUserByEmail(user));
        }
        [TestMethod]
        public void UserNotSameUserByEmail()
        {
            string DefaultUsername = "DefaultUsername";
            string DefaultPassword = "DefaultPassword";
            string DefaultName = "DefaultName";
            string DefaultSurname = "DefaultSurname";
            string DefaultEmail = "DefaultEmail@DefaultEmail.com";
            AdminUser user = new AdminUser();
            user.Username = DefaultUsername;
            user.Password = DefaultPassword;
            user.Name = DefaultName;
            user.Surname = DefaultSurname;
            user.Email = DefaultEmail;
            AdminUser user2 = user;
            user.Email = "NewEmail";
            Assert.IsFalse(user.IsSameUserByEmail(user));
        }
        [TestMethod]
        public void UserSameUserByOnlyEmail()
        {
            string DefaultUsername = "DefaultUsername";
            string DefaultPassword = "DefaultPassword";
            string DefaultName = "DefaultName";
            string DefaultSurname = "DefaultSurname";
            string DefaultEmail = "DefaultEmail@DefaultEmail.com";
            AdminUser user = new AdminUser();
            user.Username = DefaultUsername;
            user.Password = DefaultPassword;
            user.Name = DefaultName;
            user.Surname = DefaultSurname;
            user.Email = DefaultEmail;
            AdminUser user2 = user;
            user.Username = "DifferentAttribute";
            user.Password = "DifferentAttribute";
            user.Name = "DifferentAttribute";
            user.Surname = "DifferentAttribute";
            Assert.IsTrue(user.IsSameUserByEmail(user));
        }
    }
}
