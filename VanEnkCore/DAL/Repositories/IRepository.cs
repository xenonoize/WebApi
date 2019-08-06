using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Add(T entity);
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task AddAsync(T entity);
        void AddRange<TEntity>(params TEntity[] entities) where TEntity : class;
        void AddRange(params T[] entities);
        Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class;
        Task AddRangeAsync(params T[] entities);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        CollectionEntry<TEntity, TProperty> Collection<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
            where TEntity : class
            where TProperty : class;
        CollectionEntry Collection<TEntity, TProperty>(TEntity entity, string propertyName)
            where TEntity : class
            where TProperty : class;
        T Find<TKey>(TKey id);
        Task<T> FindAsync<TKey>(TKey id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindOneBy(Expression<Func<T, bool>> predicate);
        Task<T> FindOneByAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        ReferenceEntry Reference<TEntity, TProperty>(TEntity entity, string propertyName)
            where TEntity : class
            where TProperty : class;
        ReferenceEntry<TEntity, TProperty> Reference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class
            where TProperty : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void Remove(T entity);
        void RemoveRange(params T[] entities);
        void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Update(T entity);
    }
}
