namespace advancefilter.Models
{
    public class Movie
    {
        public int id { get; set; }

        public string title { get; set; }

        public string poster_path { get; set; }

        public string release_date { get; set; }

        public double vote_average { get; set; }

        public int vote_count { get; set; }

        public List<int> genre_ids { get; set; }

        public string original_language { get; set; }
    }
}