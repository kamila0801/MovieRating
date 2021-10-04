using System;
using System.Collections;
using System.Collections.Generic;
using MovieRating.Models;

namespace MovieRating.Test.DataGenerators
{
    public class GetTopMoviesByReviewerGenerator :IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[]
            {
                new List<Review>()
                {
                    new Review
                    {
                        Grade = 1, Movie = 2, Reviewer = 1, ReviewDate = new DateTime(2021, 5, 23)
                    },
                    new Review
                    {
                        Grade = 2, Movie = 1, Reviewer = 1, ReviewDate = new DateTime(2021, 4, 23)
                    },
                    new Review
                    {
                        Grade = 5, Movie = 3, Reviewer = 1, ReviewDate = new DateTime(2021, 2, 22)
                    },
                    new Review
                    {
                        Grade = 3, Movie = 3, Reviewer = 2, ReviewDate = new DateTime(2021, 3, 12)
                    }
                },
                3, 1, 2
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public static IEnumerable<object[]> DataSpecialCase =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Review>()
                    {
                        new Review
                        {
                            Grade = 2, Movie = 2, Reviewer = 1, ReviewDate = new DateTime(2021, 5, 23)
                        },
                        new Review
                        {
                            Grade = 2, Movie = 1, Reviewer = 1, ReviewDate = new DateTime(2021, 4, 23)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 3, Reviewer = 1, ReviewDate = new DateTime(2021, 2, 22)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 3, Reviewer = 2, ReviewDate = new DateTime(2021, 3, 12)
                        }
                    },
                    3, 1, 2
                }
            };
        
        public static IEnumerable<object[]> AllMoviesReviewerHasViewed =>
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
                            Grade = 5, Movie = 2, Reviewer = 1, ReviewDate = new DateTime(2021, 5, 23)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 3, Reviewer = 1, ReviewDate = new DateTime(2021, 2, 22)
                        },
                        new Review
                        {
                            Grade = 3, Movie = 3, Reviewer = 2, ReviewDate = new DateTime(2021, 3, 12)
                        }
                    },3
                }
            };
    }
}