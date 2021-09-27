using System;
using System.Collections.Generic;

namespace MovieRating
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> reviews;

        public ReviewRepository()
        {
            reviews = new List<Review>();

            var review1 = new Review
            {
                Reviewer = 1,
                Movie = 1,
                Grade = 4,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            var review2 = new Review
            {
                Reviewer = 1,
                Movie = 2,
                Grade = 3,
                ReviewDate = new DateTime(2021, 5, 23)
            };
            var review3 = new Review
            {
                Reviewer = 2,
                Movie = 1,
                Grade = 5,
                ReviewDate = new DateTime(2021, 2, 22)
            };
            var review4 = new Review
            {
                Reviewer = 2,
                Movie = 3,
                Grade = 4,
                ReviewDate = new DateTime(2021, 3, 12)
            };
            var review5 = new Review
            {
                Reviewer = 3,
                Movie = 1,
                Grade = 4,
                ReviewDate = new DateTime(2021, 6, 20)
            };
            
            reviews.Add(review1);
            reviews.Add(review2);
            reviews.Add(review3);
            reviews.Add(review4);
            reviews.Add(review5);
            
        }
        
        public void Create(Review review)
        {
            throw new System.NotImplementedException();
        }

        public List<Review> ReadAll()
        {
            return reviews;
        }

        public void Delete(Review review)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Review review)
        {
            throw new System.NotImplementedException();
        }
    }
}