using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual CollectionEntry<TEntity, TProperty> Collection<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
            where TProperty : class
            where TEntity : class
        {
            return Context.Entry(entity).Collection(propertyExpression);
        }

        public virtual CollectionEntry Collection<TEntity, TProperty>(TEntity entity, string propertyName)
            where TProperty : class
            where TEntity : class
        {
            return Context.Entry(entity).Collection(propertyName);
        }

        public virtual ReferenceEntry<TEntity, TProperty> Reference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TProperty : class
            where TEntity : class
        {
            return Context.Entry(entity).Reference(propertyExpression);
        }

        public virtual ReferenceEntry Reference<TEntity, TProperty>(TEntity entity, string propertyName)
            where TProperty : class
            where TEntity : class
        {
            return Context.Entry(entity).Reference(propertyName);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual Task AddAsync(T entity)
        {
            return DbSet.AddAsync(entity);
        }

        public virtual Task AddAsync<TEntity>(TEntity entity)
             where TEntity : class
        {
            return Context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void AddRange(params T[] entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void AddRange<TEntity>(params TEntity[] entities)
             where TEntity : class
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public virtual Task AddRangeAsync(params T[] entities)
        {
            return DbSet.AddRangeAsync(entities);
        }

        public virtual System.Threading.Tasks.Task AddRangeAsync<TEntity>(params TEntity[] entities)
            where TEntity : class
        {
            return Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual T Find<TKey>(TKey id)
        {
            return DbSet.Find(id);
        }

        public virtual Task<T> FindAsync<TKey>(TKey id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual T FindOneBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual Task<T> FindOneByAsync(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AnyAsync(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Update(entity);
        }

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Remove<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(params T[] entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual void RemoveRange<TEntity>(params TEntity[] entities)
            where TEntity : class
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual async Task<bool> TmpExists<TKey>(TKey id)
        {
            return null != await FindAsync(id);
        }
    }
}
