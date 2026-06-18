using advancedfilter.Models;

namespace advancedfilter.Services
{
    public class MovieFilterService
    {

        private readonly List<Movie> movies = new()
        {
            new Movie
            {
                Id = 1,
                Name = "Avengers",
                Genre = "Action",
                Language = "English",
                Year = 2019,
                Country = "USA",
                Rating = 8.5,
                UserRatingCount = 50000,
                Duration = 150,
                Director = "Russo Brothers",
                Actor = "Robert Downey Jr"
            },

            new Movie
            {
                Id = 2,
                Name = "RRR",
                Genre = "Action",
                Language = "Telugu",
                Year = 2022,
                Country = "India",
                Rating = 8.0,
                UserRatingCount = 70000,
                Duration = 182,
                Director = "S.S Rajamouli",
                Actor = "NTR"
            }
        };


        public List<Movie> FilterMovies(
            string? genre,
            string? language,
            int? year,
            double? minimumRating,
            double? maximumRating,
            int? duration)
        {

            var result = movies;


            if (genre != null)
            {
                result = result
                    .Where(x => x.Genre == genre)
                    .ToList();
            }


            if (language != null)
            {
                result = result
                    .Where(x => x.Language == language)
                    .ToList();
            }


            if (year != null)
            {
                result = result
                    .Where(x => x.Year >= year)
                    .ToList();
            }


            if (minimumRating != null)
            {
                result = result
                    .Where(x => x.Rating >= minimumRating)
                    .ToList();
            }


            if (maximumRating != null)
            {
                result = result
                    .Where(x => x.Rating <= maximumRating)
                    .ToList();
            }


            if (duration != null)
            {
                result = result
                    .Where(x => x.Duration <= duration)
                    .ToList();
            }


            return result;
        }
    }
}