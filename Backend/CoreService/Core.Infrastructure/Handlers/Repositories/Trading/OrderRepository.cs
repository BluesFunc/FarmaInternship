using Core.Domain.Entities.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class OrderRepository(DbContext context) : RepositoryBase<Order>(context)
{
}