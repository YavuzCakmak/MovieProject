using MicroGroup.Core.Business.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Data.Repository.Abstraction;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IPersonnelRoleService : IBusinessService<PersonnelRoleEntity, PersonnelRoleModel, IPersonnelRoleRepository, MicroGroupDbContext>
    {

    }
}
