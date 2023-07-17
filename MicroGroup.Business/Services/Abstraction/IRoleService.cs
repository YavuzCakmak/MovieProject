using MicroGroup.Core.Business.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Model.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IRoleService : IBusinessService<RoleEntity, RoleModel, IRoleRepository, MicroGroupDbContext>
    {
    }
}
