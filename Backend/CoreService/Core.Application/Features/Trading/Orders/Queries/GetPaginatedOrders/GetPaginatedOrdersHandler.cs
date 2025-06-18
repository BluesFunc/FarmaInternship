using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.Orders.Queries.GetPaginatedOrders;

public class GetPaginatedOrdersHandler :
    GetPaginatedEntitiesHandlerBase<IOrderRepository, Order, GetPaginatedOrdersCommand, OrderDto, OrderQueryParams>
{
    public GetPaginatedOrdersHandler(IMapper mapper, IOrderRepository repository) : base(mapper, repository)
    {
    }
}