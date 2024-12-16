using Domain.Core;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Abstractions.Data;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    public Task CreateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);
    public Task<List<TEntity>> GetAllByPagingAsync(Expression<Func<TEntity, bool>>? predicate = null, int currentPage = 1, int pageSize = 20, CancellationToken cancellationToken = default);
    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
}