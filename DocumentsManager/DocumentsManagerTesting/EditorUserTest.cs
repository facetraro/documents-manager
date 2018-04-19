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
    public class EditorUserTest {

        EditorUser TestEditorUser()
        {
            EditorUser user = new EditorUser();
            user.Id = Guid.NewGuid();
            user.Username = "DefaultUsername";
            user.Password = "DefaultPassword";
            user.Name = "DefaultName";
            user.Surname = "DefaultSurname";
            user.Email = "DefaultEmail@DefaultEmail.com";
            return user;
        }

        [TestMethod]
       public void EditorUserBuilderTestSameAttributes()
        {
            string DefaultUsername = "DefaultUsername";
            string DefaultPassword = "DefaultPassword";
            string DefaultName = "DefaultName";
            string DefaultSurname = "DefaultSurname";
            string DefaultEmail = "DefaultEmail@DefaultEmail.com";
            EditorUser user = TestEditorUser();
            Assert.AreEqual(user.Username,DefaultUsername);
            Assert.AreEqual(user.Password, DefaultPassword);
            Assert.AreEqual(user.Name, DefaultName);
            Assert.AreEqual(user.Surname, DefaultSurname);
            Assert.AreEqual(user.Email, DefaultEmail);
        }
        [TestMethod]
        public void EditorUserBuilderTestDifferentAttributes()
        {
            EditorUser user = TestEditorUser();
            Assert.AreNotEqual(user.Username, "DefaultUsername2");
            Assert.AreNotEqual(user.Password, "DefaultUsername2");
            Assert.AreNotEqual(user.Name, "DefaultName2");
            Assert.AreNotEqual(user.Surname, "DefaultSurname2");
            Assert.AreNotEqual(user.Email, "DefaultEmail@DefaultEmail.com2");
        }
        [TestMethod]
        public void EditorUserEqualsTest()
        {
            EditorUser user = TestEditorUser();
            Assert.IsTrue(user.Equals(user));
        }
        [TestMethod]
        public void EditorUserNotEqualsTest()
        {
            EditorUser user = TestEditorUser();
            string otherObject = "NotTheUser";
            Assert.IsFalse(user.Equals(otherObject));
        }
    }
}
