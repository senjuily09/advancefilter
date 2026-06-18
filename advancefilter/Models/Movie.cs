namespace advancedfilter.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }

        public double Rating { get; set; }

        public int UserRatingCount { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public string Actor { get; set; }
    }
}