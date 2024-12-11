﻿using System.Linq.Expressions;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Repositories.RepositoryBase
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetSingleByIdAsync(TKey id, CancellationToken cancellationToken = default, string includeProperties = "");
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, string includeProperties = "");
        IQueryable<TEntity> GetListAsNoTracking(Expression<Func<TEntity, bool>>? predicate = null, string includeProperties = "");
        IQueryable<TEntity> GetListAsTracking(Expression<Func<TEntity, bool>>? predicate = null, string includeProperties = "");
        Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void SoftDelete(TEntity entity);
        void HardDelete(TEntity entity);
        void Restore(TEntity entity);
    }
}
