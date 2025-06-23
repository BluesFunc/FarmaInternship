using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Commerce;

public class ProductQueryBuilder(IQueryable<Product> query) : QueryBuilder<Product>(query)
{
    public ProductQueryBuilder NameStartsWith(string? name)
    {
        if (name is not null)
        {
            Query = Query.Where(x => x.Name.StartsWith(name));
        }

        return this;
    }

    public ProductQueryBuilder ByStatus(ProductStatus? status)
    {
        if (status is not null)
        {
            Query = Query.Where(x => x.Status == status);
        }

        return this;
    }
}