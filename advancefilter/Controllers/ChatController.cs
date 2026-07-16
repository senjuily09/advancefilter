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
            // Create graph if it doesn't exist
            await _neo4j.SeedKnowledgeGraph();

            // Read information from Neo4j
            var context = await _neo4j.GetChatbotContext();

            // Combine graph knowledge with user question
            var prompt = $@"
Context:
{context}

User Question:
{request.Message}
";

            var answer = await _groq.Ask(prompt);

            return Ok(new
            {
                reply = answer
            });
        }
    }
}