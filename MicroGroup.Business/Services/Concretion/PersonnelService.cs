using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Core.Business.Concretion;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Model.Authorize;

namespace MicroGroup.Business.Services.Concretion
{
    public class PersonnelService : BusinessService<PersonnelEntity, PersonnelModel, IPersonnelRepository, MicroGroupDbContext>, IPersonnelService
    {
        public PersonnelService(IUnitOfWork<MicroGroupDbContext, PersonnelEntity, IPersonnelRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
