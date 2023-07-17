using MicroGroup.Core.Data.Concretion.EF;
using MicroGroup.Core.Sieve;
using MicroGroup.Core.Utilities;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Entity.MovieEvaluation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Data.Repository.Concretion
{
    public class MovieEvaluationRepository : EFRepositoryBase<MovieEvaluationEntity>, IMovieEvaluationRepository
    {
        private readonly BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> _sieveProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MovieEvaluationRepository(MicroGroupDbContext microGroupDbContext, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor) : base(microGroupDbContext, sieveProcessor, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override MovieEvaluationEntity GetById(long id, bool ShowDeleted = false)
        {
            return base.GetById(id, ShowDeleted);
        }

        public override List<MovieEvaluationEntity> GetList(Expression<Func<MovieEvaluationEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            var query = _context.Set<MovieEvaluationEntity>().AsQueryable();

            if (FetchDeletedRows == false)
            {
                query = query.Where(pr => !pr.IsDeleted);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.Include(pr => pr.Movie);
            return query.ToList();
        }
    }
}
