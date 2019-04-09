using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iStorage.DomainCore.Entities;
namespace iStorage.DomainCore.Repository
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository where TEntity : Entity
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        IQueryable<TEntity> GetManyAsQueryable(Func<TEntity, bool> where);
        TEntity Get(Func<TEntity, bool> where);
        void Delete(Func<TEntity, bool> where);
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);
        bool Exists(object primaryKey);
    }
}
