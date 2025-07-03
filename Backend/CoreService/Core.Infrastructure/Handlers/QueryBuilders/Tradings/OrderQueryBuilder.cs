using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Tradings;

public class OrderQueryBuilder(IQueryable<Order> query) : QueryBuilder<Order>(query)
{
    public OrderQueryBuilder ByUserId(Guid? userId)
    {
        if (userId is not null)
        {
            Query = Query.Where(x => x.UserId == userId);
        }

        return this;
    }

    public OrderQueryBuilder ByStatus(OrderStatus? status)
    {
        if (status is not null)
        {
            Query = Query.Where(x => x.Status == status);
        }

        return this;
    }
}