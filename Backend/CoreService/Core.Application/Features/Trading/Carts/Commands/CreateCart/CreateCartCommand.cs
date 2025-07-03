using Core.Application.Dtos.Trading;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Trading.Carts.Commands.CreateCart;

public record CreateCartCommand : IRequest<Result<CartDto>>, ITransactionRequest
{
    public Guid UserId { get; init; }
}