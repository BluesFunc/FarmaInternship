using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IPaginatedRepository<T> : IRepository<T>
    where T : Entity
{
    public Task<IReadOnlyCollection<Entity>> GetPaginatedAsync(int pageNo = 1, int pageSize = 10,
        CancellationToken cancellationToken = default);
}