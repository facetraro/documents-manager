using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;

namespace DtosAndModels.Models
{
    public class ReviewModel
    {
        public Guid CommentedId { get; set; }
        public int Rating { get; set; }
        public string FeedBack { get; set; }
        public Guid Id { get; set; }
        public ReviewModel()
        {
            CommentedId = new Guid();
            Rating = 0;
            FeedBack = "";
            Id = new Guid();
        }
        public ReviewModel(Review review)
        {
            CommentedId = review.Commented.Id;
            Id = review.Id;
            Rating = review.Rating;
            FeedBack = review.FeedBack;
        }
        public Review GetEntityModel()
        {
            DocumentContext dContext = new DocumentContext();
            Review review = new Review();
            if (!Id.Equals(Guid.Empty))
            {
                review.Id = Id;
            }
            if (!String.IsNullOrEmpty(FeedBack))
            {
                review.FeedBack = FeedBack;
            }
            review.Rating = Rating;
            review.Commented = dContext.GetById(CommentedId);
            review.Commentator = new AdminUser();
            return review;
        }
    }
}

