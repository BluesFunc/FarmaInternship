using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.OrderItems.Commands.DeleteOrderItem;

public record DeleteOrderItemByIdCommand : CommandWithEntityId<Result>;