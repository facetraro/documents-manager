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

        

        [TestMethod]
       public void EditorUserBuilderTestSameAttributes()
        {
            string DefaultUsername = "DefaultUsername";
            string DefaultPassword = "DefaultPassword";
            string DefaultName = "DefaultName";
            string DefaultSurname = "DefaultSurname";
            string DefaultEmail = "DefaultEmail@DefaultEmail.com";
            EditorUser user = ExampleInstances.TestEditorUser();
            Assert.AreEqual(user.Username,DefaultUsername);
            Assert.AreEqual(user.Password, DefaultPassword);
            Assert.AreEqual(user.Name, DefaultName);
            Assert.AreEqual(user.Surname, DefaultSurname);
            Assert.AreEqual(user.Email, DefaultEmail);
        }
        [TestMethod]
        public void EditorUserBuilderTestDifferentAttributes()
        {
            EditorUser user = ExampleInstances.TestEditorUser();
            Assert.AreNotEqual(user.Username, "DefaultUsername2");
            Assert.AreNotEqual(user.Password, "DefaultUsername2");
            Assert.AreNotEqual(user.Name, "DefaultName2");
            Assert.AreNotEqual(user.Surname, "DefaultSurname2");
            Assert.AreNotEqual(user.Email, "DefaultEmail@DefaultEmail.com2");
        }
        [TestMethod]
        public void EditorUserEqualsTest()
        {
            EditorUser user = ExampleInstances.TestEditorUser();
            Assert.IsTrue(user.Equals(user));
        }
        [TestMethod]
        public void EditorUserNotUSerEqualsTest()
        {
            EditorUser user = ExampleInstances.TestEditorUser();
            string otherObject = "NotAnUser";
            Assert.IsFalse(user.Equals(otherObject));
        }
        [TestMethod]
        public void EditorUserNotEqualsTest()
        {
            EditorUser user = ExampleInstances.TestEditorUser();
            EditorUser differentUser = ExampleInstances.TestEditorUser();
            Assert.AreNotEqual(user,differentUser);
        }
    }
}
