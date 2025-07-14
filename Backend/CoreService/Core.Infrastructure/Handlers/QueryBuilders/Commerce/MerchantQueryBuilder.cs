using Core.Domain.Entities.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Commerce;

public class MerchantQueryBuilder(IQueryable<Merchant> query) : QueryBuilder<Merchant>(query)
{
    public MerchantQueryBuilder NameStartsWith(string? name)
    {
        if (name is not null)
        {
            Query = Query.Where(x => x.Name.StartsWith(name));
        }

        return this;
    }
}