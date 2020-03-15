using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository
{
    public interface IRepository<TEntity> :IDisposable where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity,bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            );
        TEntity GetByID(int id);
        void inset(TEntity entity);
        void update(TEntity entity);
        void Save();
    }
}
