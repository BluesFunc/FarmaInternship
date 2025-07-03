using Core.Application.Dtos.Trading;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Trading.CartItems.Commands.CreateCartItem;

public record CreateCartItemCommand : IRequest<Result<CartItemDto>>, ITransactionRequest
{
    public Guid CartId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}