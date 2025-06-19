using Core.Domain.Entities.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class MerchantRepository(DbContext context) : RepositoryBase<Merchant>(context)
{
}