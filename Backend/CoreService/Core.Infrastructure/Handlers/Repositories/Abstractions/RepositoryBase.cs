using System.Linq.Expressions;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Abstractions;

public class RepositoryBase<TEntity>(DbContext context) : IGenericRepository<TEntity>
    where TEntity : Entity

{
    protected DbContext Context { get; } = context;

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().Where(filter).AnyAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await Context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return entity;
    }

    public async Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entry = await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entry.Entity;
    }


    public TEntity Update(TEntity entity)
    {
        var entry = Context.Set<TEntity>().Update(entity);
        return entry.Entity;
    }

    public bool Delete(TEntity entity)
    {
        var entry = Context.Set<TEntity>().Remove(entity);
        return entry.State == EntityState.Deleted;
    }
}