using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IFilteredRepository<T> : IGenericRepository<T>
    where T : Entity
{
    public Task<IReadOnlyCollection<T>> GetPaginatedAsync(int pageNo = 1, int pageSize = 10,
        CancellationToken cancellationToken = default);
}