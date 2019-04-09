using System;
using iStorage.DomainCore.Repository;
using iStorage.DomainCore.Entities;
using iStorage.Data.DataContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace iStorage.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected iStorageContext context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(iStorageContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual IQueryable<TEntity> GetManyAsQueryable(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).AsQueryable();
        }

        public TEntity Get(Func<TEntity, bool> where)
        {
            return dbSet.FirstOrDefault(where);
        }

        public void Delete(Func<TEntity, bool> where)
        {
            IQueryable<TEntity> objects = GetManyAsQueryable(where);
            foreach (TEntity obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = dbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) != null;
        }
    }
}
