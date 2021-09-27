using System.Collections.Generic;
using System.Linq;
using MovieRating.IServices;

namespace MovieRating.Domain.Services
{
    public class RatingService : IRatingService
    {
        private IReviewRepository _repo;
        
        public RatingService(IReviewRepository repository)
        {
            _repo = repository;
        }
        
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// We need that method in 9 to 11
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public double GetAverageRateOfMovie(int movie)
        {
            return _repo.ReadAll().Where(m => m.Movie == movie).
                Select(x => x.Grade).Average();

        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new System.NotImplementedException();
        }
        
        public List<int> GetTopRatedMovies(int amount)
        {
            return _repo.ReadAll().OrderByDescending(n => GetAverageRateOfMovie(n.Movie)).
                Select(x => x.Movie).Take(amount).ToList();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _repo.ReadAll().Where(n => n.Reviewer==reviewer).OrderByDescending(n => GetAverageRateOfMovie(n.Movie))
                .ThenByDescending(n => n.ReviewDate).Select(x => x.Movie).ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _repo.ReadAll().Where(n => n.Movie == movie).OrderByDescending(n => GetAverageRateOfMovie(n.Movie))
                .ThenByDescending(n => n.ReviewDate).Select(x => x.Reviewer).ToList();
        }
    }
}