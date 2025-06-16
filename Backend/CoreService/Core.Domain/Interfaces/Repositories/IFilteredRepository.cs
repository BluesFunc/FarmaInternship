using Core.Domain.Entities.Abstractions;
using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Interfaces.Repositories;

public interface IFilteredRepository<in TFilter, TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity
    where TFilter : PaginationQueryParams
{
    public Task<IReadOnlyCollection<TEntity>?> GetPaginatedAsync(TFilter filter,
        CancellationToken cancellationToken = default);

    public Task<TEntity?> GetEntityAsync(TFilter filter, CancellationToken cancellationToken = default);
}