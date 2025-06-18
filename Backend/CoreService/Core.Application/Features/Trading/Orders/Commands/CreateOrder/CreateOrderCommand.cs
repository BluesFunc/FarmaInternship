using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Trading.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<Result<OrderDto>>
{
    public Guid UserId { get; init; }
    public Guid CartId { get; init; }
}