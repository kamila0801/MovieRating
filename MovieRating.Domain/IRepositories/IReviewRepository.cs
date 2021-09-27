using System.Collections.Generic;

namespace MovieRating
{
    public interface IReviewRepository
    {
        void Create(Review review);
        List<Review> ReadAll();
        void Delete(Review review);
        void Update(Review review);
    }
}