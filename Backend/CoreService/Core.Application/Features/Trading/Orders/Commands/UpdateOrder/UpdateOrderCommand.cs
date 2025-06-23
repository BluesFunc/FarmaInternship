using Core.Application.Dtos.Trading;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using Core.Domain.Enums.Trading;
using MediatR;

namespace Core.Application.Features.Trading.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest<Result<OrderDto>>, ITransactionRequest
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
}