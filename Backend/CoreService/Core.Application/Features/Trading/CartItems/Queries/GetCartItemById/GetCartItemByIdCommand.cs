using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.CartItems.Queries.GetCartItemById;

public record GetCartItemByIdCommand : CommandWithEntityId<Result<CartItemDto>>;