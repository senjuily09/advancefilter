using advancefilter.Models;

namespace advancefilter.Services
{
    public class MovieFilterService
    {
        private readonly TMDBService tmdbService;

        public MovieFilterService(TMDBService tmdbService)
        {
            this.tmdbService = tmdbService;
        }


        public async Task<List<Movie>> FilterMovies(
            string? search,
            int? genre,
            string? language,
            int? year,
            double? minRating,
            double? maxRating)
        {

            var movies = await tmdbService.GetMovies();

            var result = new List<Movie>();

            foreach (var movie in movies)
            {
                bool match = true;


                if (search != null &&
                    !movie.title.ToLower().Contains(search.ToLower()))
                {
                    match = false;
                }


                if (genre != null &&
                    !movie.genre_ids.Contains(genre.Value))
                {
                    match = false;
                }


                if (language != null &&
                    movie.original_language != language)
                {
                    match = false;
                }


                if (minRating != null &&
                    movie.vote_average < minRating)
                {
                    match = false;
                }


                if (maxRating != null &&
                    movie.vote_average > maxRating)
                {
                    match = false;
                }


                if (year != null && !string.IsNullOrEmpty(movie.release_date))
                {
                    int movieYear = Convert.ToInt32(
                        movie.release_date.Substring(0, 4)
                    );

                    if (movieYear != year.Value)
                    {
                        match = false;
                    }
                }


                if (match)
                {
                    result.Add(movie);
                }

            }

            return result;
        }
    }
}