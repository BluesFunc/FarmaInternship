using System.Collections.ObjectModel;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class ProductRepository(DbContext context)
    : RepositoryBase<Product>(context), IProductRepository
{
    public async Task<IReadOnlyCollection<Product>?> GetPaginatedAsync(ProductQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Product>().AsNoTracking();

        var builder = new ProductQueryBuilder(query)
            .NameStartsWith(filter.Name)
            .ByStatus(filter.Status);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<Product>(list);

        return readOnlyList;
    }

    public async Task<Product?> GetEntityAsync(ProductQueryParams filter, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Product>().AsNoTracking();

        var builder = new ProductQueryBuilder(query)
            .NameStartsWith(filter.Name)
            .ByStatus(filter.Status);

        return await builder.GetEntityAsync(cancellationToken);
    }
}