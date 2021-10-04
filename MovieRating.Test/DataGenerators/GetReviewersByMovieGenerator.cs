using System;
using System.Collections.Generic;
using MovieRating.Models;

namespace MovieRating.Test.DataGenerators
{
    public class GetReviewersByMovieGenerator
    {
        public static IEnumerable<object[]> AllReviewersTest =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Review>()
                    {
                        new Review
                        {
                            Grade = 2, Movie = 1, Reviewer = 1, ReviewDate = new DateTime(2021, 4, 23)
                        },
                        new Review
                        {
                            Grade = 5, Movie = 1, Reviewer = 1, ReviewDate = new DateTime(2021, 5, 23)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 1, Reviewer = 1, ReviewDate = new DateTime(2021, 2, 22)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 3, Reviewer = 2, ReviewDate = new DateTime(2021, 3, 12)
                        }
                    },3
                }
            };
        
        public static IEnumerable<object[]> DescendingOrderTest =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Review>()
                    {
                        new Review
                        {
                            Grade = 3, Movie = 1, Reviewer = 1, ReviewDate = new DateTime(2021, 4, 23)
                        },
                        new Review
                        {
                            Grade = 5, Movie = 1, Reviewer = 2, ReviewDate = new DateTime(2021, 5, 23)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 1, Reviewer = 3, ReviewDate = new DateTime(2021, 2, 22)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 3, Reviewer = 2, ReviewDate = new DateTime(2021, 3, 12)
                        }
                    },2, 1, 3
                }
            };
    }
}