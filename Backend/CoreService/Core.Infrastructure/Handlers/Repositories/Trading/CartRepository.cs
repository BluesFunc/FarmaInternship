using Core.Domain.Entities.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class CartRepository(DbContext context) : RepositoryBase<Cart>(context)
{
}