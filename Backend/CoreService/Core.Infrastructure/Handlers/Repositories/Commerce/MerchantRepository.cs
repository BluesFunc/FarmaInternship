using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using Core.Infrastructure.Contexts;
using Core.Infrastructure.Handlers.Repositories.Abstractions;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class MerchantRepository(ApplicationDbContext context) : RepositoryBase<Merchant>(context), IMerchantRepository
{
    public async Task<IReadOnlyCollection<Merchant>?> GetPaginatedAsync(MerchantQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Merchant?> GetEntityAsync(MerchantQueryParams filter,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}