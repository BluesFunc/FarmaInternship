using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using Core.Domain.Enums.Trading;
using MediatR;

namespace Core.Application.Features.Trading.Carts.Commands.CreateCart;

public record CreateCartCommand : IRequest<Result<CartDto>>
{
    public Guid UserId { get; init; }
}