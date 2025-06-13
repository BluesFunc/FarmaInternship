using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using Core.Domain.Enums.Trading;
using MediatR;

namespace Core.Application.Features.Trading.Carts.Commands.UpdateCart;

public record UpdateCartCommand : IRequest<Result<CartDto>>
{
    public Guid Id { get; init; }
    public CartStatus Status { get; init; }
}