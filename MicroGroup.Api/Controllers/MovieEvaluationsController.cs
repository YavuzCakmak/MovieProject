using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Core.Utilities.Attributes;
using MicroGroup.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using MicroGroup.Model.Model.MovieEvaluation;

namespace MicroGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieEvaluationsController : ControllerBase
    {
        private readonly IMovieEvaluationService _movieEvaluationService;

        public MovieEvaluationsController(IMovieEvaluationService movieEvaluationService)
        {
            _movieEvaluationService = movieEvaluationService;
        }

        [HttpGet]
        [HasPermission]
        public IActionResult GetAll([FromQuery] DataFilterModel dataFilterModel)
        {
            return Ok(_movieEvaluationService.GetAll(dataFilterModel));
        }

        [HttpGet("{id}")]
        [HasPermission]
        public IActionResult GetById(long id)
        {
            return Ok(_movieEvaluationService.GetById(id));
        }

        [HttpGet("GetMovieAndEvaluatio")]
        [HasPermission]
        public IActionResult GetMovieAndEvaluatio([FromQuery] long movieId)
        {
            return Ok(_movieEvaluationService.GetMovieAndEvaluatio(movieId));
        }

        [HttpPost]
        [HasPermission]
        public IActionResult Add([FromBody] MovieEvaluationModel movieEvaluationModel)
        {
            return Ok(_movieEvaluationService.Add(movieEvaluationModel));
        }




        [HttpPut]
        public IActionResult Update([FromBody] MovieEvaluationModel updateModel)
        {
            return Ok(_movieEvaluationService.Update(updateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_movieEvaluationService.DeleteById(id));
        }
    }
}
