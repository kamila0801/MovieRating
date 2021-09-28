using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using MovieRating.Domain.Services;
using MovieRating.IServices;
using MovieRating.Models;
using Xunit;

namespace MovieRating.Test
{
    public class TestOneToFour
    {
        private readonly Mock<IReviewRepository> _mockRepo;
        private readonly RatingService _service;

        public TestOneToFour()
        {
            _mockRepo = new Mock<IReviewRepository>();
            _service = new RatingService(_mockRepo.Object);
            TestData();
        }

        public void TestData()
        {
            var rev1 = new Review
            {
                Reviewer = 1,
                Movie = 2,
                Grade = 3,
                ReviewDate = new DateTime(2021, 3, 25)
            };
            var rev2 = new Review
            {
                Reviewer = 1,
                Movie = 1,
                Grade = 2,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            var rev3 = new Review
            {
                Reviewer = 2,
                Movie = 2,
                Grade = 1,
                ReviewDate = new DateTime(2021, 7, 03)
            };
            var rev4 = new Review
            {
                Reviewer = 2,
                Movie = 2,
                Grade = 3,
                ReviewDate = new DateTime(2017, 8, 23)
            };
            var rev5 = new Review
            {
                Reviewer = 3,
                Movie = 3,
                Grade = 4,
                ReviewDate = new DateTime(2018, 10, 11)
            };
            var rev6 = new Review
            {
                Reviewer = 4,
                Movie = 3,
                Grade = 4,
                ReviewDate = new DateTime(2020, 2, 12)
            };
            var list = new List<Review>()
            {
                rev1, rev2, rev3, rev4, rev5, rev6
            };
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
        }


        [Fact]
        public void Test1()
        {
            int expect = 2;
            int reviewer = 1;

            int amount = _service.GetNumberOfReviewsFromReviewer(reviewer);
            Assert.Equal(expect,amount);
        }
        
        [Fact]
        public void Test2()
        {
            double expect = 2.5;
            int reviewer = 1;
            
            double result = _service.GetAverageRateFromReviewer(reviewer);
            Assert.Equal(expect,result);
        }
        
        [Fact]
        public void Test3()
        {
            var expect = 1;
            var reviewer = 1;
            var input= 2;
            
            var result = _service.GetNumberOfRatesByReviewer(reviewer, input);
            Assert.Equal(expect,result);
        }
        
        [Fact]
        public void Test4()
        {
            var expect = 3;
            var input = 2;
            
            var result = _service.GetNumberOfReviews(input);
            Assert.Equal(expect,result);
        }
    }
}