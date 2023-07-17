using MicroGroup.Core.Data.Abstraction;
using MicroGroup.Core.Utilities;
using MicroGroup.Model.Entity.Base;
using MicroGroup.Model.Model.Base;
using MicroGroup.Model.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Core.Business.Abstraction
{
    public interface IBusinessService<TEntity, TModel, TRepository, TContext>
       where TModel : BaseModel
       where TEntity : BaseEntity
       where TContext : DbContext
       where TRepository : IRepositoryBase<TEntity>
    {
        List<TModel> GetAll(DataFilterModel dataFilterModel);
        List<TModel> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false);
        DataResult GetById(long Id);
        DataResult Add(TModel model);
        DataResult Update(TModel model, bool deletion = false);
        DataResult DeleteById(long Id);
    }
}
