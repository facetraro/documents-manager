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
    public class ReviewContextTest
    {
        public void TearDown()
        {

        }
        public Review SetUp()
        {
            ClearDataBase.ClearAll();
            Review newReview = EntitiesExampleInstances.TestReview();
            UserContext contextUser = new UserContext();
            contextUser.Add(newReview.Commentator);
            DocumentContext contextDocument = new DocumentContext();
            DocumentContextTest documentTest = new DocumentContextTest();
            newReview.Commented = documentTest.setUp(contextDocument);
            return newReview;
        }
        [TestMethod]
        public void AddReviewTest()
        {
            Review newReview = SetUp();
            ReviewContext context = new ReviewContext();
            context.Add(newReview);
            List<Review> allReviews = context.GetAllReviews();
            Assert.IsTrue(allReviews.Contains(newReview));
            TearDown();
        }

        [TestMethod]
        public void RemoveFriendshipTest()
        {
            Review newReview = SetUp();
            ReviewContext context = new ReviewContext();
            context.Add(newReview);
            context.Remove(newReview);
            List<Review> allReviews = context.GetAllReviews();
            Assert.IsFalse(allReviews.Contains(newReview));
            TearDown();
        }

        [TestMethod]
        public void GetReviewTest()
        {
            Review newReview = SetUp();
            ReviewContext context = new ReviewContext();
            context.Add(newReview);
            Review result = context.GetById(newReview.Id);
            Assert.AreEqual(result.Commentator, newReview.Commentator);
            Assert.AreEqual(result.Commented, newReview.Commented);
            Assert.AreEqual(result.FeedBack, newReview.FeedBack);
            Assert.AreEqual(result.Rating, newReview.Rating);
            Assert.AreEqual(result.Id, newReview.Id);
            TearDown();
        }

        [TestMethod]
        public void GetAllReviewsTest()
        {
            Review newReview = SetUp();
            ReviewContext context = new ReviewContext();
            context.Add(newReview);
            List<Review> allReviews = context.GetAllReviews();
            Assert.IsTrue(allReviews.Contains(newReview));
            Review result = allReviews.ElementAt(0);
            Assert.AreEqual(result.Commentator, newReview.Commentator);
            Assert.AreEqual(result.Commented, newReview.Commented);
            Assert.AreEqual(result.FeedBack, newReview.FeedBack);
            Assert.AreEqual(result.Rating, newReview.Rating);
            Assert.AreEqual(result.Id, newReview.Id);
            TearDown();
        }

        [TestMethod]
        public void ModifyReviewTest()
        {
            Review newReview = SetUp();
            ReviewContext context = new ReviewContext();
            context.Add(newReview);
            newReview.Rating = 3;
            newReview.FeedBack = "Another Review";
            context.Modify(newReview);
            List<Review> allReviews = context.GetAllReviews();
            Assert.IsTrue(allReviews.Contains(newReview));
            Review result = allReviews.ElementAt(0);
            Assert.AreEqual(result.Commentator, newReview.Commentator);
            Assert.AreEqual(result.Commented, newReview.Commented);
            Assert.AreEqual(result.FeedBack, newReview.FeedBack);
            Assert.AreEqual(result.Rating, newReview.Rating);
            Assert.AreEqual(result.Id, newReview.Id);
            TearDown();
        }
    }
}
