using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Business.Services.Concretion;
using MicroGroup.Business.Session;
using MicroGroup.Business.Utilities.AuthorizeHelpers;
using MicroGroup.Core.Data.Abstraction;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Core.UnitOfWork.Concretion;
using MicroGroup.Core.Utilities.AppSettings;
using MicroGroup.Data.Repository.Concretion;
using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Entity.MovieEvaluation;
using MicroGroup.Model.MapperConfigurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroGroup.Business.Services.Concretion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.DependencyContainer
{
    public static class ConfigureContainerExtensions
    {
        public static IServiceCollection AddContainerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieEvaluationService, MovieEvaluationService>();
            services.AddScoped<IPersonnelService, PersonnelService>();
            services.AddScoped<IPersonnelRoleService, PersonnelRoleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRolePrivilegeService, RolePrivilegeService>();
            services.AddScoped<IPrivilegeService, PrivilegeService>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();


            services.AddScoped<IMovieScheduledService, MovieScheduledService>();

            services.AddScoped(typeof(IRepositoryBase<MovieEntity>), typeof(MovieRepository));
            services.AddScoped(typeof(IRepositoryBase<MovieEvaluationEntity>), typeof(MovieEvaluationRepository));
            services.AddScoped(typeof(IRepositoryBase<PersonnelEntity>), typeof(PersonnelRepository));
            services.AddScoped(typeof(IRepositoryBase<PersonnelRoleEntity>), typeof(PersonnelRoleRepository));
            services.AddScoped(typeof(IRepositoryBase<RoleEntity>), typeof(RoleRepository));
            services.AddScoped(typeof(IRepositoryBase<RolePrivilegeEntity>), typeof(RolePrivilegeRepository));
            services.AddScoped(typeof(IRepositoryBase<PrivilegeEntity>), typeof(PrivilegeRepository));

            services.AddAutoMapper(typeof(EntityToModelMapperProfile));
            services.AddAutoMapper(typeof(ModelToEntityMapperProfile));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            IConfigurationSection? sampleSection = configuration.GetSection("MicroSettings");

            services.Configure<MicroGroupSettings>(configuration.GetSection("MicroSettings"));

            services.AddScoped(typeof(IUnitOfWork<,,>), typeof(UnitOfWork<,,>));

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<SessionManager>();
            services.AddOptions();
            services.AddScoped(typeof(TokenHelper));
            return services;
        }
    }
}
