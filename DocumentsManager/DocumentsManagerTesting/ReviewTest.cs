using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void ReviewRatingTest()
        {
            Review testReview = new Review();
            int expectedValue = 5;
            testReview.Rating = expectedValue;
            Assert.IsTrue(testReview.Rating.Equals(expectedValue));
        }
        [TestMethod]
        public void ReviewFeedbackTest()
        {
            Review testReview = new Review();
            string expectedValue = "This is a Feedback";
            testReview.FeedBack = expectedValue;
            Assert.IsTrue(testReview.FeedBack.Equals(expectedValue));
        }
        [TestMethod]
        public void EqualReviewTest()
        {
            Review testReview = new Review();
            Assert.IsTrue(testReview.Equals(testReview));
        }
        [TestMethod]
        public void NotEqualReviewTest()
        {
            Review testReview = new Review();
            Review anotherReview = new Review();
            anotherReview.Id = Guid.NewGuid();
            Assert.IsFalse(testReview.Equals(anotherReview));
        }
        [TestMethod]
        public void AnotherObjectReviewTest()
        {
            Friendship testReview = new Friendship();
            Assert.IsFalse(testReview.Equals("Not a Review"));
        }
        [TestMethod]
        public void IsUserReviewedTest()
        {
            Review testReview = new Review();
            User anUser = EntitiesExampleInstances.TestAdminUser();
            testReview.Commentator = anUser;
            Assert.IsTrue(testReview.Commentator.Equals(anUser));
        }
        [TestMethod]
        public void IsNotReviewedTest()
        {
            Review testReview = new Review();
            User anUser = EntitiesExampleInstances.TestAdminUser();
            testReview.Commentator = anUser;
            Assert.IsFalse(testReview.Commentator.Equals(EntitiesExampleInstances.TestAdminUser()));
        }
        [TestMethod]
        public void IsNotReviewedDocumentTest()
        {
            Review testReview = new Review();
            Document aDocument = EntitiesExampleInstances.TestDocument();
            testReview.Commented = aDocument;
            Assert.IsFalse(testReview.Commented.Equals(EntitiesExampleInstances.TestDocument()));
        }
        [TestMethod]
        public void IsReviewedDocumentTest()
        {
            Review testReview = new Review();
            Document aDocument = EntitiesExampleInstances.TestDocument();
            testReview.Commented = aDocument;
            Assert.IsTrue(testReview.Commented.Equals(aDocument));
        }
    }
}
