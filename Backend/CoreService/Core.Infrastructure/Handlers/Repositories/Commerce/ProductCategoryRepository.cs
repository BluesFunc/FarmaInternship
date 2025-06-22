using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class ProductCategoryRepository(DbContext context)
    : RepositoryBase<ProductCategory>(context), IProductCategoryRepository
{
    public async Task<IReadOnlyCollection<ProductCategory>?> GetPaginatedAsync(ProductCategoryQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductCategory?> GetEntityAsync(ProductCategoryQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}