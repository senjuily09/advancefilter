using System.Text.Json;
using advancefilter.Models;


namespace advancefilter.Services
{
    public class TMDBService
    {

        private readonly HttpClient client;


        private string apiKey =
        "a9d997e51a29da1fc0f3173b116e07a7";


        public TMDBService(HttpClient client)
        {
            this.client = client;
        }



        public async Task<List<Movie>> GetMovies()
        {

            string url =
            $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=en-US&page=1";


            var response =
            await client.GetStringAsync(url);



            var data =
            JsonSerializer.Deserialize<TMDBResponse>(response);



            return data.results;

        }

    }



    public class TMDBResponse
    {
        public List<Movie> results { get; set; }
    }
}