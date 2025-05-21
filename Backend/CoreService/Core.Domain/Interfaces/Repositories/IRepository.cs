using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    public Task<Entity> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<Entity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Entity Update(T entity);
    public void Delete(Guid id);
}