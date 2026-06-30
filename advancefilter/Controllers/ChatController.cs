using Microsoft.AspNetCore.Mvc;
using advancefilter.Models;
using advancefilter.Services;


namespace advancefilter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {

        private readonly GroqService _ollama;


        public ChatController(GroqService ollama)
        {
            _ollama = ollama;
        }



        [HttpPost]
        public async Task<IActionResult> Chat(ChatRequest request)
        {

            var answer = await _ollama.Ask(request.Message);


            return Ok(new
            {
                reply = answer
            });

        }
    }
}