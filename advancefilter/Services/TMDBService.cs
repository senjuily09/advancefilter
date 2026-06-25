using advancefilter.Models;
using advancefilter.Models;
using System.Text.Json;

namespace advancefilter.Services
{
    public class TMDBService
    {
        private readonly HttpClient client;
        private readonly MovieCacheService cache;

        private string apiKey =
        "a9d997e51a29da1fc0f3173b116e07a7";


        public TMDBService(
            HttpClient client,
            MovieCacheService cache)
        {
            this.client = client;
            this.cache = cache;
        }



        public async Task<List<Movie>> GetMovies()
        {

            if (cache.Movies.Count > 0)
            {
                return cache.Movies;
            }


            for (int page = 1; page <= 99; page++)
            {

                string url =
                $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=en-US&page={page}";


                var response =
                await client.GetStringAsync(url);


                var data =
                JsonSerializer.Deserialize<TMDBResponse>(response);


                if (data != null)
                {
                    cache.Movies.AddRange(data.results);
                }

            }


            return cache.Movies;
        }
    }


    public class TMDBResponse
    {
        public List<Movie> results { get; set; }
    }
}