using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.CartItems.Commands.DeleteCartItem;

public record DeleteCartItemCommand : CommandWithEntityId<Result>
{
}