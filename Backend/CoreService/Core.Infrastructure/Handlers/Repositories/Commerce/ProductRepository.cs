using Core.Domain.Entities.Commerce;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Commerce;

public class ProductRepository(DbContext context) : RepositoryBase<Product>(context)
{
}