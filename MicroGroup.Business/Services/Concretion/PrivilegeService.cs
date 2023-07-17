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
    public class PrivilegeService : BusinessService<PrivilegeEntity, PrivilegeModel, IPrivilegeRepository, MicroGroupDbContext>, IPrivilegeService
    {
        public PrivilegeService(IUnitOfWork<MicroGroupDbContext, PrivilegeEntity, IPrivilegeRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
