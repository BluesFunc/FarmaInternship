using System.Linq.Expressions;
using System.Numerics;
using Auth.Domain.Entities.Abstractions;
using Auth.Domain.Interfaces.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories.Abstractions;

public abstract class RepositoryBase<T>(DbContext context) : IFilterRepository<T>
    where T : Entity
{
    public T AddEntity(T entity)
    {
        var entry = context.Set<T>().Add(entity);
        return entry.Entity;
    }

    public T UpdateEntity(T entity)
    {
        var entry = context.Set<T>().Update(entity);
        return entry.Entity;
    }

    public async Task<T?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await GetEntityAsync(x => x.Id == id, cancellationToken);
    }

    public void RemoveEntity(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> EntityExistAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().AsNoTracking()
            .Where(filter).AnyAsync(cancellationToken);
    }

    public async Task<T?> GetEntityAsync(Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        var entity = await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);

        return entity;
    }
}