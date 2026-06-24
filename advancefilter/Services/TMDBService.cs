using System.Text.Json;
using advancefilter.Models;

namespace advancefilter.Services
{
    public class TMDBService
    {
        private readonly HttpClient client;
        private List<Movie> movies = new();

        private string apiKey =
        "a9d997e51a29da1fc0f3173b116e07a7";

        public TMDBService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<Movie>> GetMovies()
        {

            // If movies already loaded, return them
            if (movies.Count > 0)
            {
                return movies;
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
                    movies.AddRange(data.results);
                }

            }
            return movies;

        }

    }


    public class TMDBResponse
    {
        public List<Movie> results { get; set; }
    }
}