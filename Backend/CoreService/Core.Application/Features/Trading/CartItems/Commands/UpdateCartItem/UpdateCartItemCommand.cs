using Core.Application.Dtos.Trading;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Trading.CartItems.Commands.UpdateCartItem;

public record UpdateCartItemCommand : IRequest<Result<CartItemDto>>, ITransactionRequest
{
    public Guid CartItemId { get; init; }
    public Guid CartId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}