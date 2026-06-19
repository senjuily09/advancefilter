namespace advancedfilter.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Poster_Path { get; set; }

        public string Release_Date { get; set; }

        public double Vote_Average { get; set; }

        public int Vote_Count { get; set; }


        // Extra fields for filtering

        public int Genre { get; set; }

        public string Language { get; set; }

        public int Duration { get; set; }
    }
}