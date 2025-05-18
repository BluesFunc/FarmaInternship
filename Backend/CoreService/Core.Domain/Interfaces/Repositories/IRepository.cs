using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    public Task<Entity> AddAsync(T entity);
    public Task<Entity> GetByIdAsync(Guid id);
    public Entity Update(T entity);
    public void Delete(Guid id);
}