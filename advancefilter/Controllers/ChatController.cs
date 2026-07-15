using advancefilter.Models;
using advancefilter.Services;
using Microsoft.AspNetCore.Mvc;
namespace advancefilter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly GroqService _groq;
        private readonly Neo4jService _neo4j;

        public ChatController(GroqService groq, Neo4jService neo4j)
        {
            _groq = groq;
            _neo4j = neo4j;
        }

        [HttpPost]
        public async Task<IActionResult> Chat(ChatRequest request)
        {
            // Temporary test: Add a movie node to Neo4j
            await _neo4j.CreateMovie("Interstellar", "Sci-Fi");

            // Get chatbot response from Groq
            var answer = await _groq.Ask(request.Message);

            return Ok(new
            {
                reply = answer
            });
        }
    }
}