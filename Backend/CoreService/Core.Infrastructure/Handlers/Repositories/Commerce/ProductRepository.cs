using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class ProductRepository(DbContext context)
    : RepositoryBase<Product>(context), IProductRepository
{
    public async Task<IReadOnlyCollection<Product>?> GetPaginatedAsync(ProductQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetEntityAsync(ProductQueryParams filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}