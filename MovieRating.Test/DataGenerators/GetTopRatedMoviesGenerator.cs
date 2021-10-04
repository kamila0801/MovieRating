﻿using System;
using System.Collections;
using System.Collections.Generic;
using MovieRating.Models;

namespace MovieRating.Test.DataGenerators
{
    public  class GetTopRatedMoviesGenerator: IEnumerable<object[]>
    {
        
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Review>()
                {
                    new Review
                    {
                        Grade = 2, Movie = 1, Reviewer = 1
                    },
                    new Review
                    {
                        Grade = 5, Movie = 2, Reviewer = 1
                    },
                    new Review
                    {
                        Grade = 3, Movie = 3, Reviewer = 1
                    }
                },
                2, 2, 3
            };
            yield return new object[]
            {
                new List<Review>()
                {
                    new Review
                    {
                        Grade = 5, Movie = 1, Reviewer = 1
                    },
                    new Review
                    {
                        Grade = 4, Movie = 2, Reviewer = 1
                    },
                    new Review
                    {
                        Grade = 3, Movie = 3, Reviewer = 1
                    }
                },
                2, 1, 2
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public static IEnumerable<object[]> SpecialCase =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Review>()
                    {
                        new Review
                        {
                            Grade = 5, Movie = 2
                        },
                        new Review
                        {
                            Grade = 4, Movie = 1
                        },
                        new Review
                        {
                            Grade = 4, Movie = 1, Reviewer = 3, ReviewDate = new DateTime(2021, 2, 22)
                        },
                        new Review
                        {
                            Grade = 4, Movie = 3, Reviewer = 2, ReviewDate = new DateTime(2021, 3, 12)
                        },
                        new Review
                        {
                            Grade = 1, Movie = 67,
                        }
                    },2, 1, 3
                }
            };
    }
    
}