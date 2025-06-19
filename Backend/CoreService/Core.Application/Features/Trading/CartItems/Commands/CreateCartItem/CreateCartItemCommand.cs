using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Trading.CartItems.Commands.CreateCartItem;

public record CreateCartItemCommand : IRequest<Result<CartItemDto>>
{
    public Guid CartId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}