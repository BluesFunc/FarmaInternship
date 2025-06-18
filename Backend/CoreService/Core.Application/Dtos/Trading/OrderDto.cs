using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Mapster;

namespace Core.Application.Dtos.Trading;

public record OrderDto : IMapFrom<Order>
{
    public decimal TotalAmount { get; init; }
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public IReadOnlyCollection<OrderItemDto> OrderItems { get; private set; } = [];
}