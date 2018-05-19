using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;
using DocumentsManager.Data.DA.Handler;
using System.Linq;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class FriendshipContextTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        [TestMethod]
        public void AddFriendshipTest()
        {
            Friendship newFriendship = EntitiesExampleInstances.TestFriendship();
            UserContext contextUser = new UserContext();
            contextUser.Add(newFriendship.Request);
            contextUser.Add(newFriendship.Requested);
            FriendshipContext context = new FriendshipContext();
            context.Add(newFriendship);
            List<Friendship> allFriendships = context.GetAllFriendships();
            Assert.IsTrue(allFriendships.Contains(newFriendship));
            TearDown();
        }
        [TestMethod]
        public void RemoveFriendshipTest()
        {
            Friendship newFriendship = EntitiesExampleInstances.TestFriendship();
            UserContext contextUser = new UserContext();
            contextUser.Add(newFriendship.Request);
            contextUser.Add(newFriendship.Requested);
            FriendshipContext context = new FriendshipContext();
            context.Add(newFriendship);
            context.Remove(newFriendship);
            List<Friendship> allFriendships = context.GetAllFriendships();
            Assert.IsFalse(allFriendships.Contains(newFriendship));
            TearDown();
        }
        [TestMethod]
        public void GetFriendshipTest()
        {
            Friendship newFriendship = EntitiesExampleInstances.TestFriendship();
            UserContext contextUser = new UserContext();
            contextUser.Add(newFriendship.Request);
            contextUser.Add(newFriendship.Requested);
            FriendshipContext context = new FriendshipContext();
            context.Add(newFriendship);
            Friendship result = context.GetById(newFriendship.Id);
            Assert.AreEqual(result.Request, newFriendship.Request);
            Assert.AreEqual(result.Requested, newFriendship.Requested);
            Assert.AreEqual(result.State, newFriendship.State);
            Assert.AreEqual(result.Id, newFriendship.Id);
            TearDown();
        }
        [TestMethod]
        public void GetAllFriendshipsTest()
        {
            Friendship newFriendship = EntitiesExampleInstances.TestFriendship();
            UserContext contextUser = new UserContext();
            contextUser.Add(newFriendship.Request);
            contextUser.Add(newFriendship.Requested);
            FriendshipContext context = new FriendshipContext();
            context.Add(newFriendship);
            Friendship result = context.GetById(newFriendship.Id);           
            List<Friendship> allFriendships = context.GetAllFriendships();
            Assert.IsTrue(allFriendships.Contains(newFriendship));
            Assert.AreEqual(allFriendships.ElementAt(0).Requested, newFriendship.Requested);
            Assert.AreEqual(allFriendships.ElementAt(0).Request, newFriendship.Request);
            Assert.AreEqual(allFriendships.ElementAt(0).State, newFriendship.State);
            Assert.AreEqual(allFriendships.ElementAt(0).Id, newFriendship.Id);
            TearDown();
        }
        [TestMethod]
        public void ModifyStateFriendshipTest()
        {
            Friendship newFriendship = EntitiesExampleInstances.TestFriendship();
            UserContext contextUser = new UserContext();
            contextUser.Add(newFriendship.Request);
            contextUser.Add(newFriendship.Requested);
            newFriendship.State = FriendshipState.Request;
            FriendshipContext context = new FriendshipContext();
            context.Add(newFriendship);
            newFriendship.State = FriendshipState.Friend;
            context.Modify(newFriendship);
            Friendship result = context.GetById(newFriendship.Id);
            List<Friendship> allFriendships = context.GetAllFriendships();
            Assert.IsTrue(allFriendships.Contains(newFriendship));
            Assert.AreEqual(allFriendships.ElementAt(0).Requested, newFriendship.Requested);
            Assert.AreEqual(allFriendships.ElementAt(0).Request, newFriendship.Request);
            Assert.AreEqual(allFriendships.ElementAt(0).State, newFriendship.State);
            Assert.AreEqual(allFriendships.ElementAt(0).Id, newFriendship.Id);
            TearDown();
        }
    }
}
