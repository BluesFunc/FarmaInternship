using Core.Domain.Entities.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Commerce;

public class ProductCategoryQueryBuilder(IQueryable<ProductCategory> query)
    : QueryBuilder<ProductCategory>(query)
{
    public ProductCategoryQueryBuilder NameStartsWith(string? name)
    {
        if (name is not null)
        {
            Query = Query.Where(x => x.Name.StartsWith(name));
        }

        return this;
    }
}