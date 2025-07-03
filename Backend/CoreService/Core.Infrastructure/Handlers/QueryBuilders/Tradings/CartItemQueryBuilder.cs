using Core.Domain.Entities.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Tradings;

public class CartItemQueryBuilder(IQueryable<CartItem> query) : QueryBuilder<CartItem>(query)
{
    public CartItemQueryBuilder ByCartId(Guid? cartId)
    {
        if (cartId is not null)
        {
            Query = Query.Where(x => x.CartId == cartId);
        }

        return this;
    }


    public CartItemQueryBuilder ByProductId(Guid? productId)
    {
        if (productId is not null)
        {
            Query = Query.Where(x => x.ProductId == productId);
        }

        return this;
    }
}