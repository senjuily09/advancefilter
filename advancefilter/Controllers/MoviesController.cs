using Microsoft.AspNetCore.Mvc;
using advancedfilter.Services;

namespace advancedfilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly MovieFilterService service;


        public MoviesController(MovieFilterService service)
        {
            this.service = service;
        }



        [HttpGet("filter")]
        public IActionResult FilterMovies(
            string? genre,
            string? language,
            int? year,
            double? minimumRating,
            double? maximumRating,
            int? duration)
        {

            var result = service.FilterMovies(
                genre,
                language,
                year,
                minimumRating,
                maximumRating,
                duration
            );


            return Ok(result);
        }

    }
}