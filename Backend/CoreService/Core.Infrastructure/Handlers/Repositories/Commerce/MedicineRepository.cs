using System.Collections.ObjectModel;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.QueryBuilders.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class MedicineRepository(DbContext context)
    : RepositoryBase<Medicine>(context), IMedicineRepository
{
    public async Task<IReadOnlyCollection<Medicine>?> GetPaginatedAsync(MedicineQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Medicine>().AsNoTracking();

        var builder = new MedicineQueryBuilder(query)
            .NameStartsWith(filter.Name)
            .ByType(filter.Type)
            .ByManufacturerName(filter.ManufacturerName)
            .ByManufacturerOrigin(filter.ManufacturerOrigin);

        var list = await builder.BuildPaginatedListAsync(filter, cancellationToken);

        var readOnlyList = new ReadOnlyCollection<Medicine>(list);

        return readOnlyList;
    }

    public async Task<Medicine?> GetEntityAsync(MedicineQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Medicine>().AsNoTracking();

        var builder = new MedicineQueryBuilder(query)
            .NameStartsWith(filter.Name)
            .ByType(filter.Type)
            .ByManufacturerName(filter.ManufacturerName)
            .ByManufacturerOrigin(filter.ManufacturerOrigin);

        return await builder.GetEntityAsync(cancellationToken);
    }
}