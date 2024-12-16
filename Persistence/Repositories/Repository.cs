using Application.Abstractions.Data;
using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{

    private readonly DatabaseContext _context;

    public Repository(DatabaseContext context) => _context = context;

    public async Task CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>().AsNoTracking();
        if (predicate is not null) queryable = queryable.Where(predicate);
        return await queryable.ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllByPagingAsync(Expression<Func<TEntity, bool>>? predicate = null, int currentPage = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>().AsNoTracking();
        if (predicate is not null) queryable = queryable.Where(predicate);

        return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>().AsNoTracking();
        if (include is not null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await Task.Run(() => _context.Set<TEntity>().Remove(entity));
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Run(() => _context.Set<TEntity>().Update(entity));
        return entity;
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        _context.Set<TEntity>().AsNoTracking();
        if (predicate is null)
        {
            return await _context.Set<TEntity>().CountAsync();
        }
        return await _context.Set<TEntity>().Where(predicate).CountAsync();
    }
}
