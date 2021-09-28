using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MovieRating.Domain.Services;
using MovieRating.IServices;
using MovieRating.Models;
using Xunit;

namespace MovieRating.Test
{
    public class RatingServiceTest
    {
        private readonly Mock<IReviewRepository> _mockRepo;
        private readonly IRatingService _service;

        public RatingServiceTest()
        {
            _mockRepo = new Mock<IReviewRepository>();
            _service = new RatingService(_mockRepo.Object);
        }

        [Fact]
        public void GetTopRatedMovies_ShouldReturn_N_Movies_WithBestRating()
        {
            //Arrange
            var rev1 = new Review
            {
                Grade = 2,
                Movie = 1,
                Reviewer = 1
            };
            var rev2 = new Review
            {
                Grade = 5,
                Movie = 2,
                Reviewer = 1
            };
            var rev3 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 1
            };
            var list = new List<Review>()
            {
                rev1, rev2, rev3
            };
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
            //Act
            var movies = _service.GetTopRatedMovies(2);
            //Assert
            Assert.True(movies.Count==2);
            Assert.True(movies.ElementAt(0) ==rev2.Movie);
            Assert.True(movies.ElementAt(1)==rev3.Movie);
        }

        [Fact]
        public void GetTopMoviesByReviewer_ShouldReturn_MoviesSortedInDescendingOrder_ByRate_AndDate()
        {
            var rev1 = new Review
            {
                Grade = 2,
                Movie = 1,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            //before rev1
            var rev2 = new Review
            {
                Grade = 2,
                Movie = 2,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 5, 23)
            };
            var rev3 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 2, 22)
            };
            var rev4 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 3, 12)
            };
            var list = new List<Review>()
            {
                rev1, rev2, rev3, rev4
            };
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
            //Act
            var moviesByReviewer = _service.GetTopMoviesByReviewer(1);
            //Assert
            Assert.True(moviesByReviewer.ElementAt(0)==rev3.Movie);
            Assert.True(moviesByReviewer.ElementAt(1)==rev2.Movie);
            Assert.True(moviesByReviewer.ElementAt(2)==rev1.Movie);
        }
        
        [Fact]
        public void GetTopMoviesByReviewer_ShouldReturn_AllMoviesReviewerHasViewed()
        {
            var rev1 = new Review
            {
                Grade = 2,
                Movie = 1,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            var rev2 = new Review
            {
                Grade = 5,
                Movie = 2,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 5, 23)
            };
            var rev3 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 2, 22)
            };
            var rev4 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 3, 12)
            };
            var list = new List<Review>()
            {
                rev1, rev2, rev3, rev4
            };
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
            //Act
            var moviesByReviewer = _service.GetTopMoviesByReviewer(1);
            //Assert
            Assert.True(moviesByReviewer.Count==3);
        }
        
        [Fact]
        public void GetReviewersByMovie_ShouldReturn_AllReviewers_ThatRatedThatMovie()
        {
            //Arrange
            var rev1 = new Review
            {
                Grade = 2,
                Movie = 1,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            var rev2 = new Review
            {
                Grade = 5,
                Movie = 1,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 5, 23)
            };
            var rev3 = new Review
            {
                Grade = 3,
                Movie = 1,
                Reviewer = 3,
                ReviewDate = new DateTime(2021, 2, 22)
            };
            var rev4 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 3, 12)
            };
            var list = new List<Review>()
            {
                rev1, rev2, rev3, rev4
            };
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
            //Act
            var reviewersForMovie = _service.GetReviewersByMovie(1);
            //Assert
            Assert.True(reviewersForMovie.Count==3);
        }
        
        [Fact]
        public void GetReviewersByMovie_ShouldReturn_ListSortedIn_DescendingOrder()
        {
            //Arrange
            //before
            var rev1 = new Review
            {
                Grade = 3,
                Movie = 1,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            var rev2 = new Review
            {
                Grade = 5,
                Movie = 1,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 5, 23)
            };
            var rev3 = new Review
            {
                Grade = 3,
                Movie = 1,
                Reviewer = 3,
                ReviewDate = new DateTime(2021, 2, 22)
            };
            var rev4 = new Review
            {
                Grade = 3,
                Movie = 3,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 3, 12)
            };
            var list = new List<Review>()
            {
                rev1, rev2, rev3, rev4
            };
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
            //Act
            var reviewersForMovie = _service.GetReviewersByMovie(1);
            //Assert
            Assert.True(reviewersForMovie.ElementAt(0)==rev2.Reviewer);
            Assert.True(reviewersForMovie.ElementAt(1)==rev1.Reviewer);
            Assert.True(reviewersForMovie.ElementAt(2)==rev3.Reviewer);
        }

        #region Invalid Arguments

        [Fact]
        public void GetTopRatedMovies_Should_Throw_Exception_WhenParameter_IsZeroOrLess()
        {
            _mockRepo.Setup(x => x.ReadAll()).Returns(new List<Review>());
            void Act1() => _service.GetTopRatedMovies(0);
            void Act2() => _service.GetTopRatedMovies(-10);
            var exception1 = Assert.Throws<ArgumentException>(Act1);
            var exception2 = Assert.Throws<ArgumentException>(Act2);
            Assert.Equal("amount must be greater than 0", exception1.Message);
            Assert.Equal("amount must be greater than 0", exception2.Message);
        }

        [Fact]
        public void GetTopMoviesByReviewer_ShouldThrowException_When_ReviewerDoesnt_Exist()
        {
            _mockRepo.Setup(x => x.ReadAll()).Returns(new List<Review>());
            void Act1() => _service.GetTopMoviesByReviewer(0);
            var exception1 = Assert.Throws<ArgumentException>(Act1);
            Assert.Equal("reviewer doesnt exist", exception1.Message);
        }
        
        
        [Fact]
        public void GetReviewersByMovie_ShouldThrowException_IfMovieDoesntExist()
        {
            //Arrange
            var rev1 = new Review
            {
                Grade = 3,
                Movie = 1,
                Reviewer = 1,
                ReviewDate = new DateTime(2021, 4, 23)
            };
            var rev2 = new Review
            {
                Grade = 5,
                Movie = 1,
                Reviewer = 2,
                ReviewDate = new DateTime(2021, 5, 23)
            };
            var list = new List<Review>() {rev1, rev2};
            _mockRepo.Setup(x => x.ReadAll()).Returns(list);
            //Act
            void Act() => _service.GetReviewersByMovie(100);
            //Assert
            var exception1 = Assert.Throws<ArgumentException>(Act);
            Assert.Equal("movie doesnt exist", exception1.Message);
        }
        

        #endregion
        
        
    }
}