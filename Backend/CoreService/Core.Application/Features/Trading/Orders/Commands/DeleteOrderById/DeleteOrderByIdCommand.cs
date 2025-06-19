using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.Orders.Commands.DeleteOrderById;

public record DeleteOrderByIdCommand : CommandWithEntityId<Result>
{
}