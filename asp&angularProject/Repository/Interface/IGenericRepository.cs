using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IGenericRepository<T>
    {
        Task AddEntityAsync(T message);
        void AddEntity(T entity);
        void updateEntity(T entity);
        List<T> getEntity (bool track);
        Task< List<T>> getEntityAsync (bool track);
        Task< List<T>> getEntityAsync (Expression<Func<T,bool>> expression,bool track);
        Task< List<T>> getEntityWithIncludeAsync (string includes ,Expression<Func<T,bool>> filter = null, Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null);
         List<T> getEntityWithInclude( Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        List<T> getEntity (Expression<Func<T,bool>> expression,bool track);
        T getEntityById(Guid id);
        Task< T> getEntityAsyncById(Guid id);
    }
}