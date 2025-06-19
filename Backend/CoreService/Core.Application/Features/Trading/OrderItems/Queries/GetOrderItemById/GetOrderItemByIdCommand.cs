using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.OrderItems.Queries.GetOrderItemById;

public record GetOrderItemByIdCommand : CommandWithEntityId<Result<OrderItemDto>>;