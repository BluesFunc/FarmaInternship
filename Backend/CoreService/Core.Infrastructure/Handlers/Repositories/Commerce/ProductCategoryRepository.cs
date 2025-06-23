using System.Collections.ObjectModel;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class ProductCategoryRepository(DbContext context)
    : RepositoryBase<ProductCategory>(context), IProductCategoryRepository
{
    public async Task<IReadOnlyCollection<ProductCategory>?> GetPaginatedAsync(ProductCategoryQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<ProductCategory>().AsNoTracking();

        var builder = new ProductCategoryQueryBuilder(query)
            .NameStartsWith(filter.Name);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<ProductCategory>(list);

        return readOnlyList;
    }

    public async Task<ProductCategory?> GetEntityAsync(ProductCategoryQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<ProductCategory>().AsNoTracking();

        var builder = new ProductCategoryQueryBuilder(query)
            .NameStartsWith(filter.Name);

        return await builder.GetEntityAsync(cancellationToken);
    }
}