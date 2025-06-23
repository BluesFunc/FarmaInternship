using System.Collections.ObjectModel;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Tradings;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class OrderItemRepository(DbContext context) : RepositoryBase<OrderItem>(context), IOrderItemRepository
{
    public async Task<IReadOnlyCollection<OrderItem>?> GetPaginatedAsync(OrderItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<OrderItem>().AsNoTracking();

        var builder = new OrderItemQueryBuilder(query)
            .ByProductId(filter.ProductId)
            .ByOrderId(filter.OrderId);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<OrderItem>(list);

        return readOnlyList;
    }

    public async Task<OrderItem?> GetEntityAsync(OrderItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<OrderItem>().AsNoTracking();

        var builder = new OrderItemQueryBuilder(query)
            .ByProductId(filter.ProductId)
            .ByOrderId(filter.OrderId);


        return await builder.GetEntityAsync(cancellationToken);
    }
}