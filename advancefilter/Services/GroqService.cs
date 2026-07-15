using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace advancefilter.Services
{
    public class GroqService
    {
        private readonly HttpClient _client;

        private readonly string apiKey = "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";

        public GroqService(HttpClient client)
        {
            _client = client;
        }
        

        public async Task<string> Ask(string question)
        {
            var requestBody = new
            {
                model = "llama-3.1-8b-instant",
                messages = new[]
                {
            new
            {
                role = "system",
                content = "You are MovieBot. Only answer questions related to movies. Help users find movies, genres, ratings, actors, recommendations."
            },
            new
            {
                role = "user",
                content = question
            }
        }
            };


            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://api.groq.com/openai/v1/chat/completions"
            );


            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);


            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );


            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();


            var json = await response.Content.ReadAsStringAsync();


            using var doc = JsonDocument.Parse(json);


            var message = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();


            return message;
        }
    }
}