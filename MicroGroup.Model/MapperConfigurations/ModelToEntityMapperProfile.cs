using AutoMapper;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Base;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Entity.MovieEvaluation;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Model.Model.Base;
using MicroGroup.Model.Model.Movie;
using MicroGroup.Model.Model.MovieEvaluation;

namespace MicroGroup.Model.MapperConfigurations
{
    public class ModelToEntityMapperProfile : Profile
    {
        public ModelToEntityMapperProfile()
        {
            CreateMap<BaseModel, BaseEntity>();


            CreateMap<MovieModel, MovieEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<MovieEvaluationModel, MovieEvaluationEntity>().IncludeBase<BaseModel, BaseEntity>();


            #region Authorize
            CreateMap<PersonnelModel, PersonnelEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<RoleModel, RoleEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<PersonnelRoleModel, PersonnelRoleEntity>()
                .ForMember(x => x.Personnel, source => source.Ignore())
                .ForMember(x => x.Role, source => source.Ignore())
                .IncludeBase<BaseModel, BaseEntity>();

            CreateMap<PrivilegeModel, PrivilegeEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<RolePrivilegeModel, RolePrivilegeEntity>()
                .ForMember(x => x.RoleId, source => source.MapFrom(src => src.Role.Id))
                .ForMember(x => x.PrivilegeId, source => source.MapFrom(src => src.Privilege.Id))
                .IncludeBase<BaseModel, BaseEntity>();

            #endregion
        }
    }
}
