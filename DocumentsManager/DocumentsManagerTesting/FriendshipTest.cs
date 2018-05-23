using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class FriendshipTest
    {
        [TestMethod]
        public void EqualFriendshipTest()
        {
            Friendship testFriendship = new Friendship();
            Assert.IsTrue(testFriendship.Equals(testFriendship));
        }
        [TestMethod]
        public void NotEqualFriendshipTest()
        {
            Friendship testFriendship = new Friendship();
            Friendship anotherFriendship = new Friendship();
            anotherFriendship.Id = Guid.NewGuid();
            Assert.IsFalse(testFriendship.Equals(anotherFriendship));
        }
        [TestMethod]
        public void AnotherObjectFriendshipTest()
        {
            Friendship testFriendship = new Friendship();
            Assert.IsFalse(testFriendship.Equals("Not a friendship"));
        }
        [TestMethod]
        public void IsFriendshipTest()
        {
            Friendship testFriendship = new Friendship();
            testFriendship.State = FriendshipState.Friend;
            Assert.IsTrue(testFriendship.IsFriendship());
        }
        [TestMethod]
        public void IsNotFriendshipTest()
        {
            Friendship testFriendship = new Friendship();
            testFriendship.State = FriendshipState.Request;
            Assert.IsFalse(testFriendship.IsFriendship());
        }
        [TestMethod]
        public void IsRequestTest()
        {
            Friendship testFriendship = new Friendship();
            testFriendship.State = FriendshipState.Request;
            Assert.IsTrue(testFriendship.IsRequest());
        }
        [TestMethod]
        public void IsNotRequestTest()
        {
            Friendship testFriendship = new Friendship();
            testFriendship.State = FriendshipState.Friend;
            Assert.IsFalse(testFriendship.IsRequest());
        }
        [TestMethod]
        public void IsRequestedTest()
        {
            Friendship testFriendship = new Friendship();
            User anUser = EntitiesExampleInstances.TestAdminUser();
            testFriendship.Requested = anUser;
            Assert.IsTrue(testFriendship.Requested.Equals(anUser));
        }
        [TestMethod]
        public void IsUserRequestTest()
        {
            Friendship testFriendship = new Friendship();
            User anUser = EntitiesExampleInstances.TestAdminUser();
            testFriendship.Request = anUser;
            Assert.IsTrue(testFriendship.Request.Equals(anUser));
        }
        [TestMethod]
        public void IsNotRequestedTest()
        {
            Friendship testFriendship = new Friendship();
            User anUser = EntitiesExampleInstances.TestAdminUser();
            testFriendship.Request = anUser;
            Assert.IsFalse(testFriendship.Request.Equals(EntitiesExampleInstances.TestAdminUser()));
        }
        [TestMethod]
        public void IsNotRequestUserTest()
        {
            Friendship testFriendship = new Friendship();
            User anUser = EntitiesExampleInstances.TestAdminUser();
            testFriendship.Request = anUser;
            Assert.IsFalse(testFriendship.Request.Equals(EntitiesExampleInstances.TestAdminUser()));
        }
    }
}
