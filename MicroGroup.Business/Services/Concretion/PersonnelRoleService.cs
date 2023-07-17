using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Core.Business.Concretion;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Data.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MicroGroup.Business.Services.Concretion
{
    public class PersonnelRoleService : BusinessService<PersonnelRoleEntity, PersonnelRoleModel, IPersonnelRoleRepository, MicroGroupDbContext>, IPersonnelRoleService
    {
        public PersonnelRoleService(IUnitOfWork<MicroGroupDbContext, PersonnelRoleEntity, IPersonnelRoleRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
