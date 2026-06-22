using Microsoft.AspNetCore.Mvc;
using advancefilter.Services;


namespace advancefilter.Controllers
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
        public async Task<IActionResult> FilterMovies(

            string? search,
            int? genre,
            string? language,
            int? year,
            double? minRating,
            double? maxRating

        )
        {


            var movies =
            await service.FilterMovies(
                search,
                genre,
                language,
                year,
                minRating,
                maxRating
            );


            return Ok(new
            {
                results = movies
            });

        }

    }

}