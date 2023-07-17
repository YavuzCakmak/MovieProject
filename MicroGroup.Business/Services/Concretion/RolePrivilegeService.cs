using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Core.Business.Concretion;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Model.Model.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Concretion
{
    public class RolePrivilegeService : BusinessService<RolePrivilegeEntity, RolePrivilegeModel, IRolePrivilegeRepository, MicroGroupDbContext>, IRolePrivilegeService
    {
        public RolePrivilegeService(IUnitOfWork<MicroGroupDbContext, RolePrivilegeEntity, IRolePrivilegeRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
