using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Abstractions;

namespace Core.Infrastructure.Handlers.QueryBuilders.Commerce;

public class MedicineQueryBuilder(IQueryable<Medicine> query)
    : QueryBuilder<Medicine>(query)
{
    public MedicineQueryBuilder NameStartsWith(string? name)
    {
        if (name is not null)
        {
            Query = Query.Where(x => x.Name.StartsWith(name));
        }

        return this;
    }

    public MedicineQueryBuilder ByType(MedicineType? type)
    {
        if (type is not null)
        {
            Query = Query.Where(x => x.Type == type);
        }

        return this;
    }

    public MedicineQueryBuilder ByManufacturerOrigin(string? manufacturerOrigin)
    {
        if (manufacturerOrigin is not null)
        {
            Query = Query.Where(x => x.ManufacturerOrigin == manufacturerOrigin);
        }

        return this;
    }

    public MedicineQueryBuilder ByManufacturerName(string? manufacturerName)
    {
        if (manufacturerName is not null)
        {
            Query = Query.Where(x => x.ManufacturerOrigin == manufacturerName);
        }

        return this;
    }
}