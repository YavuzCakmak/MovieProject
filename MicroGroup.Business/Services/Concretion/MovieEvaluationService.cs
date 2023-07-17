using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Business.Session;
using MicroGroup.Core.Business.Concretion;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.MovieEvaluation;
using MicroGroup.Model.Model.MovieEvaluation;
using MicroGroup.Model.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace MicroGroup.Business.Services.Concretion
{
    public class MovieEvaluationService : BusinessService<MovieEvaluationEntity, MovieEvaluationModel, IMovieEvaluationRepository, MicroGroupDbContext>, IMovieEvaluationService
    {
        private readonly SessionManager _sessionManager;

        public MovieEvaluationService(IUnitOfWork<MicroGroupDbContext, MovieEvaluationEntity, IMovieEvaluationRepository> uow, IMapper mapper, SessionManager sessionManager) : base(uow, mapper)
        {
            _sessionManager = sessionManager;
        }

        public override DataResult Add(MovieEvaluationModel model)
        {
            model.PersonnelId = _sessionManager.User.PersonnelId;
            return base.Add(model);
        }

        /// <summary>
        /// Kullanıcın not verdiği ve puanladığı filmler
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public List<MovieEvaluationModel> GetMovieAndEvaluatio(long movieId)
        {
            List<MovieEvaluationModel> movieEvaluationModels = new List<MovieEvaluationModel>();
            movieEvaluationModels = base.GetList(x => x.MovieId == movieId && x.PersonnelId == _sessionManager.User.PersonnelId);

            return movieEvaluationModels;
        }
    }
}
