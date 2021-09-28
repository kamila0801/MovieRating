using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieRating.IServices;
using MovieRating.Models;

namespace MovieRating.Domain.Services
{
    public class RatingService : IRatingService
    {
        private IReviewRepository _repo;

        public RatingService(IReviewRepository repository)
        {
            _repo = repository;
        }
        //Test1
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<Review> allReviews = _repo.ReadAll();
            int i = 0;

            foreach (var r in allReviews)
            {
                if (r.Reviewer == reviewer)
                {
                    i++;
                }
            }

            return i;
        }
        //Test2
        public double GetAverageRateFromReviewer(int reviewer)
        {
            List<Review> allReviews = _repo.ReadAll();
            double total = 0;
            int count = 0;
            
            foreach (var r in allReviews)
            {
                if (r.Reviewer == reviewer)
                {
                    total += r.Grade;
                    count++;
                }
            }
            
            if (count == 0)
            {
                throw new InvalidDataException("This reviewer has no reviews");
            }
            
            double result = total / count;
            return result;
        }
        //Test3
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            List<Review> allReviews = _repo.ReadAll();
            int count = 0;
            
            if (rate< 1 || rate > 5)
            {
                throw new InvalidDataException("The grade have to be between 1-5");
            }
            
            foreach (var r in allReviews)
            {
                if (r.Reviewer == reviewer && r.Grade == rate)
                {
                    count++;
                }
            }
            return count;
        }
        //Test4
        public int GetNumberOfReviews(int movie)
        {
            List<Review> allReviews = _repo.ReadAll();
            int count = 0;
            
            foreach (var r in allReviews)
            {
                if (r.Movie == movie)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                throw new InvalidDataException("This movie has no reviews");
            }
            return count;
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