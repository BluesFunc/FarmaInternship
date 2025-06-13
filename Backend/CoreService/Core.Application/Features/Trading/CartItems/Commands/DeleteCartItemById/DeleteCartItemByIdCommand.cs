using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.CartItems.Commands.DeleteCartItemById;

public record DeleteCartItemByIdCommand : CommandWithEntityId<Result>
{
}