using MicroGroup.Core.Data.Abstraction;
using MicroGroup.Core.Sieve;
using MicroGroup.Core.Utilities;
using MicroGroup.Model.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using System.Linq.Expressions;
using System.Net;
using static Sieve.Extensions.MethodInfoExtended;

namespace MicroGroup.Core.Data.Concretion.EF
{
    public class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
    {
        public DbContext _context { get; set; }

        private readonly BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> _sieveProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EFRepositoryBase(DbContext context, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _sieveProcessor = sieveProcessor;
            _httpContextAccessor = httpContextAccessor;
        }

        protected DbSet<TEntity> _dbSet;
        public TEntity Entity { get; set; }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);

            this.Entity = entity;
        }

        public void Delete(long id)
        {
            TEntity entity = GetById(id, true);

            if (entity == null)
                throw new Exception("Silinecek öğe bulunamadı", new Exception(HttpStatusCode.NotFound.ToString()));

            entity.IsDeleted = true;

            this.Update(entity, deletion: true);
        }

        public IQueryable<TEntity> GetAll(DataFilterModel dataFilterModel)
        {
            IQueryable<TEntity> data;

            try
            {
                data = _sieveProcessor.Apply<TEntity>(dataFilterModel, _dbSet.AsNoTracking().Where(x => !x.IsDeleted), applyPagination: false);

                _httpContextAccessor.HttpContext.Response.Headers.Add("X-Total-Count", data.Count().ToString());

                data = _sieveProcessor.Apply<TEntity>(dataFilterModel, data);
            }
            catch (Exception ex)
            {
                throw ex;// silersen data hata verir.(use of unasigned local variable)
                         // core katmanına özgü bir exception yazılıp atılabilir.
            }
            return data;
        }

        public virtual TEntity GetById(long id, bool ShowDeleted = false)
        {
            if (id != null)
            {
                if (ShowDeleted == false)
                {
                    return _context.Set<TEntity>().Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
                }
                else
                {
                    return _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault()!;
                }
            }
            throw new Exception("Id is Null", new Exception(HttpStatusCode.BadRequest.ToString()));
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            return filter == null
           ? _context.Set<TEntity>().ToList()
           : _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity, bool deletion = false)
        {
            if (entity == null)
            {
                throw new Exception("Güncellenecek öğe bulunamadı", new Exception(HttpStatusCode.BadRequest.ToString()));
            }
            entity.IsDeleted = deletion;
            _dbSet.Update(entity);
        }
    }
}
