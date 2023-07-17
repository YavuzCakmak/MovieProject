using MicroGroup.Core.Data.Concretion.EF;
using MicroGroup.Core.Sieve;
using MicroGroup.Core.Utilities;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MicroGroup.Data.Repository.Abstraction;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Data.Repository.Concretion
{
    public class PersonnelRoleRepository : EFRepositoryBase<PersonnelRoleEntity>, IPersonnelRoleRepository
    {
        private readonly BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> _sieveProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PersonnelRoleRepository(MicroGroupDbContext microGroupDbContext, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor) : base(microGroupDbContext, sieveProcessor, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override List<PersonnelRoleEntity> GetList(Expression<Func<PersonnelRoleEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            var query = _context.Set<PersonnelRoleEntity>().AsQueryable();

            if (FetchDeletedRows == false)
            {
                query = query.Where(pr => !pr.IsDeleted);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.Include(pr => pr.Role);

            return query.ToList();
        }

        public override PersonnelRoleEntity GetById(long id, bool ShowDeleted = false)
        {
            return base.GetById(id, ShowDeleted);
        }
    }
}
