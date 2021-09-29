using System;
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
            if(!_repo.ReadAll().Any(m => m.Movie == movie))
                throw new ArgumentException("There is no movie with this id");
            return _repo.ReadAll().Where(m => m.Movie == movie)
                .Select(x => x.Grade).Average();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            if (!_repo.ReadAll().Any(r=>r.Movie == movie))
                throw new ArgumentException("There is no movie with this id");
            if (!_repo.ReadAll().Any(r=>r.Grade == rate))
                throw new ArgumentException("The rate must be a number between 1 and 5");
            return _repo.ReadAll().Where(r => r.Movie == movie && r.Grade == rate)
                .ToList().Count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var list = _repo.ReadAll().Where(r => r.Grade == 5)
                .GroupBy(r => r.Movie)
                .Select(group => new { 
                    Metric = group.Key, 
                    Count = group.Count() 
                })
                .OrderByDescending(g => g.Count)
                .ToList();
            
            if (!list.Any())
                return null;
            
            var results = new List<int> {list[0].Metric};

            for (int i = 1; i < list.Count; i++)
            {
                if(list[i].Count == list[0].Count)
                   results.Add(list[i].Metric); 
                else break;
            }
            return results;
        }

        public List<int> GetMostProductiveReviewers()
        {
            var list = _repo.ReadAll()
                .GroupBy(r => r.Reviewer)
                .Select(group => new { 
                    Metric = group.Key, 
                    Count = group.Count() 
                })
                .OrderByDescending(g => g.Count)
                .ToList();
            
            if (!list.Any())
                return null;
            
            var results = new List<int> {list[0].Metric};
            
            for (int i = 1; i < list.Count; i++)
            {
                if(list[i].Count == list[0].Count)
                    results.Add(list[i].Metric); 
                else break;
            }
            return results;
            
        }
        
        public List<int> GetTopRatedMovies(int amount)
        {
            if (amount < 1)
                throw new ArgumentException("amount must be greater than 0");
            return _repo.ReadAll().OrderByDescending(n => GetAverageRateOfMovie(n.Movie)).
                Select(x => x.Movie).Take(amount).ToList();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            if (_repo.ReadAll().FirstOrDefault(n => n.Reviewer == reviewer) == null)
                throw new ArgumentException("reviewer doesnt exist");
            return _repo.ReadAll().Where(n => n.Reviewer==reviewer).OrderByDescending(n => GetAverageRateOfMovie(n.Movie))
                .ThenByDescending(n => n.ReviewDate).Select(x => x.Movie).ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            if (_repo.ReadAll().FirstOrDefault(n => n.Movie == movie) == null)
                throw new ArgumentException("movie doesnt exist");
            return _repo.ReadAll().Where(n => n.Movie == movie).OrderByDescending(n => GetAverageRateOfMovie(n.Movie))
                .ThenByDescending(n => n.ReviewDate).Select(x => x.Reviewer).ToList();
        }
    }
}