using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CassandraCSharpDriver_Sample.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Int32 id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, Boolean>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, Boolean>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}