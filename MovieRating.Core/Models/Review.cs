using System;

namespace MovieRating
{
    public class Review
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}