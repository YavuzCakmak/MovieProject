using MicroGroup.Core.Data.Abstraction;
using MicroGroup.Model.Entity.Base;
using MicroGroup.Model.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Core.UnitOfWork.Abstraction
{
    public interface IUnitOfWork<TContext, TEntity, TRepository> : IDisposable
        where TContext : DbContext
        where TEntity : BaseEntity
        where TRepository : IRepositoryBase<TEntity>
    {
        TRepository Repository { get; }
        void CommitTransaction();
        DataResult SaveChanges();
    }
}
