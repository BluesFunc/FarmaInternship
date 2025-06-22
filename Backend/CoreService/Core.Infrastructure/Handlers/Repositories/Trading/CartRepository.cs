using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class CartRepository(DbContext context) : RepositoryBase<Cart>(context), ICartRepository
{
    public async Task<IReadOnlyCollection<Cart>?> GetPaginatedAsync(CartQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Cart?> GetEntityAsync(CartQueryParams filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}