using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Core.Business.Concretion;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Model.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Concretion
{
    public class RoleService : BusinessService<RoleEntity, RoleModel, IRoleRepository, MicroGroupDbContext>, IRoleService
    {
        public RoleService(IUnitOfWork<MicroGroupDbContext, RoleEntity, IRoleRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
