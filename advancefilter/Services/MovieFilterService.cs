using advancedfilter.Models;


namespace advancedfilter.Services
{
    public class MovieFilterService
    {

        private List<Movie> movies = new()
        {

            new Movie
            {
                Id = 1,
                Title = "Avengers",
                Poster_Path = "/poster.jpg",
                Release_Date = "2019-04-26",
                Vote_Average = 8.5,
                Vote_Count = 50000,
                Genre = 28,
                Language = "en",
                Duration = 150
            },


            new Movie
            {
                Id = 2,
                Title = "RRR",
                Poster_Path = "/rrr.jpg",
                Release_Date = "2022-03-25",
                Vote_Average = 8.0,
                Vote_Count = 70000,
                Genre = 28,
                Language = "tel",
                Duration = 182
            }

        };



        public List<Movie> FilterMovies(
            string? search,
            int? genre,
            string? language,
            int? year,
            double? minRating,
            double? maxRating,
            int? duration)
        {

            List<Movie> result = new List<Movie>();


            int i = 0;


            while (i < movies.Count)
            {

                Movie movie = movies[i];


                bool match = true;



                // Search filter
                if (search != null)
                {
                    if (!movie.Title
                        .ToLower()
                        .Contains(search.ToLower()))
                    {
                        match = false;
                    }
                }



                // Genre filter
                if (genre != null)
                {
                    if (movie.Genre != genre)
                    {
                        match = false;
                    }
                }



                // Language filter
                if (language != null)
                {
                    if (movie.Language != language)
                    {
                        match = false;
                    }
                }



                // Year filter
                if (year != null)
                {
                    int movieYear =
                    Convert.ToInt32(
                    movie.Release_Date.Substring(0, 4));


                    if (movieYear < year)
                    {
                        match = false;
                    }
                }



                // Minimum rating
                if (minRating != null)
                {
                    if (movie.Vote_Average < minRating)
                    {
                        match = false;
                    }
                }



                // Maximum rating
                if (maxRating != null)
                {
                    if (movie.Vote_Average > maxRating)
                    {
                        match = false;
                    }
                }



                // Duration
                if (duration != null)
                {
                    if (movie.Duration > duration)
                    {
                        match = false;
                    }
                }



                if (match)
                {
                    result.Add(movie);
                }


                i++;

            }


            return result;

        }

    }
}