using MicroGroup.Core.Data.Concretion.EF;
using MicroGroup.Core.Sieve;
using MicroGroup.Core.Utilities;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;

namespace MicroGroup.Data.Repository.Concretion
{
    public class PersonnelRepository : EFRepositoryBase<PersonnelEntity>, IPersonnelRepository
    {
        private readonly BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> _sieveProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PersonnelRepository(MicroGroupDbContext microGroupDbContext, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor) : base(microGroupDbContext, sieveProcessor, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
