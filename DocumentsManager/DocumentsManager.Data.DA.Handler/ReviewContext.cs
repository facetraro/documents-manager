using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class ReviewContext
    {
        public void Add(Review newReview)
        {
            Review reviewToDB = newReview;
            reviewToDB.Commented.Header.Text.StyleClass = null;
            reviewToDB.Commented.Footer.Text.StyleClass = null;
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Users.Attach(reviewToDB.Commentator);
                db.Documents.Attach(reviewToDB.Commented);
                unitOfWork.ReviewRepository.Insert(reviewToDB);
            }
        }
        public List<Review> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.ReviewRepository.Get().ToList();
            }
        }
        public List<Review> GetAllReviews()
        {
            List<Review> allReviews = new List<Review>();
            foreach (var item in GetLazy())
            {
                allReviews.Add(GetById(item.Id));
            }
            return allReviews;
        }
        public void ClearAll()
        {
            foreach (var item in GetAllReviews())
            {
                Remove(item);
            }
        }
        public void Remove(Review review)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.ReviewRepository.Delete(review);
            }
        }
        public Review GetById(Guid id)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                Review review = unitOfWork.ReviewRepository.GetByID(id);
                db.Reviews.Include("Commented").ToList();
                db.Reviews.Include("Commentator").ToList();
                return review;
            }
        }
        public bool Modify(Review modifiedReview)
        {
            bool modified = false;
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                unitOfWork.ReviewRepository.Update(modifiedReview);
                modified = true;
            }
            return modified;
        }
    }
}
