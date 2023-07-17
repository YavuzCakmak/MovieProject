using MicroGroup.Core.Data.Concretion.EF;
using MicroGroup.Core.Sieve;
using MicroGroup.Core.Utilities;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Data.Repository.Concretion
{
    public class RoleRepository : EFRepositoryBase<RoleEntity>, IRoleRepository
    {
        private readonly BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> _sieveProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleRepository(MicroGroupDbContext microGroupDbContext, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor) : base(microGroupDbContext, sieveProcessor, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
