using Core.Domain.Entities.Commerce;
using Core.Domain.Entities.Trading;
using Mapster;

namespace Core.Application.Dtos.Trading;

public record OrderItemDto : IMapFrom<OrderItem>
{
    public required Order OrderObject { get; init; }
    public required Product ProductObject { get; init; }
    public int Quantity { get; set; }
    public decimal PriceAtOrder { get; set; }
}