using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class OrderRepository(DbContext context) : RepositoryBase<Order>(context), IOrderRepository
{
    public async Task<IReadOnlyCollection<Order>?> GetPaginatedAsync(OrderQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Order?> GetEntityAsync(OrderQueryParams filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}