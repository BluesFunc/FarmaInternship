using Core.Domain.Entities.Trading;
using Core.Infrastructure.Handlers.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Handlers.Repositories.Trading;

public class OrderItemRepository(DbContext context) : RepositoryBase<OrderItem>(context)
{
}