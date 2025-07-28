using Core.Application.Dtos.Commerce;
using Core.Domain.Entities.Commerce;
using Core.Domain.Entities.Trading;
using Mapster;

namespace Core.Application.Dtos.Trading;

public record OrderItemDto : IMapFrom<OrderItem>
{
    public required ProductDto ProductObject { get; init; }
    public int Quantity { get; set; }
    public decimal PriceAtOrder { get; set; }
}