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
            string? search,
            int? genre,
            string? language,
            int? year,
            double? minRating,
            double? maxRating,
            int? duration
            )
        {


            var result = service.FilterMovies(
                search,
                genre,
                language,
                year,
                minRating,
                maxRating,
                duration
            );


            return Ok(new
            {
                results = result
            });

        }

    }
}