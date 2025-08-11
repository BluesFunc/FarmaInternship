using System.Collections.ObjectModel;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Tradings;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class CartItemRepository(DbContext context) : RepositoryBase<CartItem>(context), ICartItemRepository
{
    public async Task<IReadOnlyCollection<CartItem>?> GetPaginatedAsync(CartItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<CartItem>().AsNoTracking();

        query = query.Include(x => x.ProductObject);

        var builder = new CartItemQueryBuilder(query)
            .ByCartId(filter.CartId)
            .ByProductId(filter.UserId);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<CartItem>(list);

        return readOnlyList;
    }

    public async Task<CartItem?> GetEntityAsync(CartItemQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<CartItem>().AsNoTracking();

        var builder = new CartItemQueryBuilder(query)
            .ByCartId(filter.CartId)
            .ByProductId(filter.UserId);

        return await builder.GetEntityAsync(cancellationToken);
    }
}