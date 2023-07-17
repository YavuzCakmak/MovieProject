using MicroGroup.Core.Business.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Entity.MovieEvaluation;
using MicroGroup.Model.Model.Movie;
using MicroGroup.Model.Model.MovieEvaluation;
using MicroGroup.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IMovieEvaluationService : IBusinessService<MovieEvaluationEntity, MovieEvaluationModel, IMovieEvaluationRepository, MicroGroupDbContext>
    {
        public List<MovieEvaluationModel> GetMovieAndEvaluatio(long movieId);

    }
}
