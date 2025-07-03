using Core.Domain.Entities.Abstractions;
using Core.Domain.Models.QueryParams.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

public abstract class QueryBuilder<TEntity>(IQueryable<TEntity> query)
    where TEntity : Entity
{
    protected IQueryable<TEntity> Query = query;

    public async Task<List<TEntity>> BuildPaginatedListAsync(PaginationQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        Query = Query.Skip((filter.PageNo - 1) * filter.PageSize)
            .Take(filter.PageSize);
        return await Query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetEntityAsync(CancellationToken cancellationToken = default)
    {
        return await Query.FirstOrDefaultAsync(cancellationToken);
    }
}