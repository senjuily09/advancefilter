using System.Text.Json;

namespace advancefilter.Services
{
    public class OllamaService
    {
        private readonly HttpClient _client;

        public OllamaService(HttpClient client)
        {
            _client = client;        }


        public async Task<string> Ask(string question)
        {
            var request = new
            {
                model = "llama3.1:8b",
                prompt =
     $"""
    You are MovieBot.
    You only answer questions about movies.

    Help users with:
    - movie recommendations
    - genres
    - ratings
    - actors
    - release years
    - movie details

    User question:
    {question}
    """,
                stream = false
            };


            var response = await _client.PostAsJsonAsync(
                "http://localhost:11434/api/generate",
                request
            );


            response.EnsureSuccessStatusCode();


            var result = await response.Content
                .ReadFromJsonAsync<OllamaResponse>();


            return result.response;
        }
    }


    public class OllamaResponse
    {
        public string response { get; set; }
    }
}