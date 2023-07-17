using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Business.Services.Concretion;
using MicroGroup.Core.Utilities;
using MicroGroup.Core.Utilities.Attributes;
using MicroGroup.Model.Dto;
using MicroGroup.Model.Model.Movie;
using Microsoft.AspNetCore.Mvc;

namespace MicroGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [HasPermission]
        public IActionResult GetAll([FromQuery] DataFilterModel dataFilterModel)
        {
            return Ok(_movieService.GetAll(dataFilterModel));
        }

        [HttpGet("{id}")]
        [HasPermission]
        public IActionResult GetById(long id)
        {
            return Ok(_movieService.GetById(id));
        }

        [HttpPost]
        [HasPermission]
        public IActionResult Add([FromBody] MovieModel movieModel)
        {
            return Ok(_movieService.Add(movieModel));
        }

        [HttpPost("AdviceMovie")]
        [HasPermission]
        public IActionResult AdviceMovie([FromBody] AdviceMovieDto adviceMovieDto)
        {
            _movieService.AdviceMovie(adviceMovieDto);
            return Ok();
        }

        [HttpPost("AddForScheduled")]
        public IActionResult AddForScheduled([FromBody] MovieModel movieModel)
        {
            return Ok(_movieService.Add(movieModel));
        }

        [HttpPut]
        [HasPermission]
        public IActionResult Update([FromBody] MovieModel updateModel)
        {
            return Ok(_movieService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        [HasPermission]
        public IActionResult Delete(long id)
        {
            return Ok(_movieService.DeleteById(id));
        }
    }
}
