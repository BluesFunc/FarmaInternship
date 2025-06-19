using System.Linq.Expressions;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Abstractions;

public class RepositoryBase<TEntity>(DbContext context) : IGenericRepository<TEntity>
    where TEntity : Entity

{
    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().Where(filter).AnyAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity;
    }

    public async Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entry = await context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entry.Entity;
    }


    public TEntity Update(TEntity entity)
    {
        var entry = context.Set<TEntity>().Update(entity);
        return entry.Entity;
    }

    public bool Delete(TEntity entity)
    {
        var entry = context.Set<TEntity>().Remove(entity);
        return entry.State == EntityState.Deleted;
    }
}