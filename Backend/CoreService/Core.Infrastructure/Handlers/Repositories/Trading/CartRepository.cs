using System.Collections.ObjectModel;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using Core.Infrastructure.Handlers.QueryBuilders.Tradings;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class CartRepository(DbContext context) : RepositoryBase<Cart>(context), ICartRepository
{
    public async Task<IReadOnlyCollection<Cart>?> GetPaginatedAsync(CartQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Cart>().AsNoTracking();

        query = query.Include(x => x.CartItems);

        var builder = new CartQueryBuilder(query)
            .ByStatus(filter.Status)
            .ByUserId(filter.UserId);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<Cart>(list);

        return readOnlyList;
    }

    public async Task<Cart?> GetEntityAsync(CartQueryParams filter, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Cart>().AsNoTracking();

        query = query.Include(x => x.CartItems);

        var builder = new CartQueryBuilder(query)
            .ByStatus(filter.Status)
            .ByUserId(filter.UserId);

        return await builder.GetEntityAsync(cancellationToken);
    }
}