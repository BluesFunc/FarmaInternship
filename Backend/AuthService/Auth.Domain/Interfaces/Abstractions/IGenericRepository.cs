using System.Numerics;
using Auth.Domain.Entities.Abstractions;

namespace Auth.Domain.Interfaces.Abstractions;

public interface IGenericRepository<T> where T : Entity
{
    public T AddEntity(T entity);
    public T UpdateEntity(T entity);
    public Task<T?> GetEntityByIdAsync(Guid  id, CancellationToken cancellationToken = default);
    public void RemoveEntity(T entity);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}