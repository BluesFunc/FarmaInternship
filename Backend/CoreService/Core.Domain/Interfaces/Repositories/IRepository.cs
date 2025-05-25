using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public T Update(T entity);
    public void Delete(Guid id);
}