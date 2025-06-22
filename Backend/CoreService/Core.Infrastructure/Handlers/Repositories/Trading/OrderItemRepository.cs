using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class OrderItemRepository(DbContext context) : RepositoryBase<OrderItem>(context), IOrderItemRepository
{
    public async Task<IReadOnlyCollection<OrderItem>?> GetPaginatedAsync(OrderItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderItem?> GetEntityAsync(OrderItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}