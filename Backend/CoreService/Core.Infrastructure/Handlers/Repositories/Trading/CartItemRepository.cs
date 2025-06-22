using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class CartItemRepository(DbContext context) : RepositoryBase<CartItem>(context), ICartItemRepository
{
    public async Task<IReadOnlyCollection<CartItem>?> GetPaginatedAsync(CartItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<CartItem?> GetEntityAsync(CartItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}