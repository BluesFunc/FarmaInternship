using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class MedicineRepository(DbContext context)
    : RepositoryBase<Medicine>(context), IMedicineRepository
{
    public async Task<IReadOnlyCollection<Medicine>?> GetPaginatedAsync(MedicineQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Medicine?> GetEntityAsync(MedicineQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}