using System.Collections.ObjectModel;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Tradings;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class OrderRepository(DbContext context) : RepositoryBase<Order>(context), IOrderRepository
{
    public async Task<IReadOnlyCollection<Order>?> GetPaginatedAsync(OrderQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Order>().AsNoTracking();

        query = query.Include(x => x.OrderItems);

        var builder = new OrderQueryBuilder(query)
            .ByStatus(filter.Status)
            .ByUserId(filter.UserId);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<Order>(list);

        return readOnlyList;
    }

    public async Task<Order?> GetEntityAsync(OrderQueryParams filter, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Order>().AsNoTracking();

        var builder = new OrderQueryBuilder(query)
            .ByStatus(filter.Status)
            .ByUserId(filter.UserId);


        return await builder.GetEntityAsync(cancellationToken);
    }
}