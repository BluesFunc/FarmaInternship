using Domain.Entities.Abstractions;

namespace Domain.Interfaces.Abstractions;

public interface IGenericRepository<T> where T : Entity
{
    public T AddEntity(T entity);
    public T UpdateEntity(T entity);
    public Task<T?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public void RemoveEntity(T entity);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}