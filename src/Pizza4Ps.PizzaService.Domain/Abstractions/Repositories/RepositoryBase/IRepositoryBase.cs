﻿using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetSingleByIdAsync(TKey id, string includeProperties = "", CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? predicate = null, string includeProperties = "", CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetListAsNoTracking(Expression<Func<TEntity, bool>>? predicate = null, string includeProperties = "");
        IQueryable<TEntity> GetListAsTracking(Expression<Func<TEntity, bool>>? predicate = null, string includeProperties = "");
        Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Update(TEntity entity);
        void SoftDelete(TEntity entity);
        void HardDelete(TEntity entity);
        void Restore(TEntity entity);
    }
}
