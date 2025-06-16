using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.OrderItems.Queries.GetPaginatedOrderItems;

public class GetPaginatedOrderItemsHandler :
    GetPaginatedEntitiesHandlerBase<IOrderItemRepository, OrderItem, GetPaginatedOrderItemsCommand, OrderItemDto,
        OrderItemQueryParams>
{
    public GetPaginatedOrderItemsHandler(IMapper mapper, IOrderItemRepository repository) : base(mapper, repository)
    {
    }
}