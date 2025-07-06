using System.Linq.Expressions;
using Auth.Domain.Entities.Abstractions;

namespace Auth.Domain.Interfaces.Abstractions;

public interface IFilterRepository<T> : IGenericRepository<T>
where T : Entity
{
    public Task<bool> IsExistAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    public Task<T?> GetEntityAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
}