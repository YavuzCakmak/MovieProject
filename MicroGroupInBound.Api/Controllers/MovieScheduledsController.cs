using MicroGroup.Business.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieScheduledsController : ControllerBase
    {
        private readonly IMovieScheduledService _movieScheduledService;

        public MovieScheduledsController(IMovieScheduledService movieScheduledService)
        {
            _movieScheduledService = movieScheduledService;
        }

        [HttpGet("GetMoviesAndSave")]
        public IActionResult GetMoviesAndSave()
        {
            _movieScheduledService.GetMovieAndSave();
            return Ok();
        }
    }
}
