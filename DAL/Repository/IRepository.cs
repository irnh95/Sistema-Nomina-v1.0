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
        void DeleteBatch(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity,bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            );
        TEntity GetByID(int id);
        void Add(TEntity entity);
        void AddBatch(IEnumerable<TEntity> entities);
        void update(TEntity entity);
        void Save();
    }
}
