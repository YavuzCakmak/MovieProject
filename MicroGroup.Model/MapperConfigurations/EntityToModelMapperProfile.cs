using AutoMapper;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Base;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Entity.MovieEvaluation;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Model.Model.Base;
using MicroGroup.Model.Model.Movie;
using MicroGroup.Model.Model.MovieEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Model.MapperConfigurations
{
    public class EntityToModelMapperProfile : Profile
    {
        public EntityToModelMapperProfile()
        {
            CreateMap<BaseEntity, BaseModel>();


            #region Movie
            CreateMap<MovieEntity, MovieModel>().IncludeBase<BaseEntity, BaseModel>();
            #endregion

            #region MovieEvaluation
            CreateMap<MovieEvaluationEntity, MovieEvaluationModel>().IncludeBase<BaseEntity, BaseModel>();
            #endregion

            #region Authorizes
            CreateMap<PersonnelEntity, PersonnelModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<RoleEntity, RoleModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<PersonnelRoleEntity, PersonnelRoleModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<PrivilegeEntity, PrivilegeModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<RolePrivilegeEntity, RolePrivilegeModel>().IncludeBase<BaseEntity, BaseModel>();

            #endregion
        }
    }
}
