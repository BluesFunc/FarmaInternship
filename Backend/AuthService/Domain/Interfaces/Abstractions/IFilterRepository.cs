using System.Linq.Expressions;
using Domain.Entities.Abstractions;

namespace Domain.Interfaces.Abstractions;

public interface IFilterRepository<T>
    where T : Entity
{
    public Task<bool> IsExistAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    public Task<T?> GetEntityAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
}