using MicroGroup.Core.Business.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Model.Authorize;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IPrivilegeService : IBusinessService<PrivilegeEntity, PrivilegeModel, IPrivilegeRepository, MicroGroupDbContext>
    {
    }
}
