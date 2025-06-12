using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : Entity
{
    public Task<T?> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public T Update(T entity);
    public bool Delete(T entity);
}