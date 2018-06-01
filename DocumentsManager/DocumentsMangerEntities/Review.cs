using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsMangerEntities
{
    public class Review
    {
        public User Commentator { get; set; }
        public Document Commented { get; set; }
        public int Rating { get; set; }
        public string FeedBack { get; set; }
        public Guid Id { get; set; }
        public override bool Equals(object obj)
        {
            Review anotherReview = obj as Review;
            if ((System.Object)anotherReview == null)
            {
                return false;
            }
            return Id.Equals(anotherReview.Id);
        }
    }
}
