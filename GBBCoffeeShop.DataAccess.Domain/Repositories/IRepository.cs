using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories
{
    /// <summary>
    /// Generic repository with methods necessary for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
                
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
