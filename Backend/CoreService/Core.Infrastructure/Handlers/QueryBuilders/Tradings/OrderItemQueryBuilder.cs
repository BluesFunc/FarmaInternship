using Core.Domain.Entities.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Tradings;

public class OrderItemQueryBuilder(IQueryable<OrderItem> query) : QueryBuilder<OrderItem>(query)
{
    public OrderItemQueryBuilder ByOrderId(Guid? orderId)
    {
        if (orderId is not null)
        {
            Query = Query.Where(x => x.OrderId == orderId);
        }

        return this;
    }

    public OrderItemQueryBuilder ByProductId(Guid? productId)
    {
        if (productId is not null)
        {
            Query = Query.Where(x => x.OrderId == productId);
        }

        return this;
    }
}