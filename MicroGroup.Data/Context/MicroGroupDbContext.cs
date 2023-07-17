using MicroGroup.Model.Entity.Authorize;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Entity.MovieEvaluation;
using Microsoft.EntityFrameworkCore;

namespace MicroGroup.Data.Context
{
    public class MicroGroupDbContext : DbContext
    {
        public MicroGroupDbContext(DbContextOptions<MicroGroupDbContext> options) : base(options)
        {
        }


        public DbSet<MovieEntity> MovieEntities { get; set; }
        public DbSet<MovieEvaluationEntity> MovieEvaluationEntities { get; set; }
        public DbSet<PersonnelEntity> PersonnelEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RolePrivilegeEntity> RolePrivilegeEntities { get; set; }
        public DbSet<PrivilegeEntity> PrivilegeEntities { get; set; }
        public DbSet<PersonnelRoleEntity> PersonnelRoleEntities { get; set; }
    }
}
