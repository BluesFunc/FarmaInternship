using System.Linq.Expressions;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : Entity
{
    Task<bool> IsExistAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    public Task<T?> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public T Update(T entity);
    public bool Delete(T entity);
}