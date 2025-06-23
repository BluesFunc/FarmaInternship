using System.Collections.ObjectModel;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class MerchantRepository(DbContext context) : RepositoryBase<Merchant>(context), IMerchantRepository
{
    public async Task<IReadOnlyCollection<Merchant>?> GetPaginatedAsync(MerchantQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Merchant>().AsNoTracking();

        var builder = new MerchantQueryBuilder(query)
            .NameStartsWith(filter.Name);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<Merchant>(list);

        return readOnlyList;
    }

    public async Task<Merchant?> GetEntityAsync(MerchantQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Merchant>().AsNoTracking();

        var builder = new MerchantQueryBuilder(query)
            .NameStartsWith(filter.Name);

        return await builder.GetEntityAsync(cancellationToken);
    }
}