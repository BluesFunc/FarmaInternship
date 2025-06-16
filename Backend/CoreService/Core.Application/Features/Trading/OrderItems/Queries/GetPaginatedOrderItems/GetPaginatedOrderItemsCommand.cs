using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

namespace Core.Application.Features.Trading.OrderItems.Queries.GetPaginatedOrderItems;

public record GetPaginatedOrderItemsCommand : GetPaginatedEntitiesCommand<OrderItemDto>;