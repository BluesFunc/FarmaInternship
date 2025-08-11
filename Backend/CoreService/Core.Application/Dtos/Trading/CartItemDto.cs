using Core.Application.Dtos.Commerce;
using Core.Domain.Entities.Trading;
using Mapster;

namespace Core.Application.Dtos.Trading;

public class CartItemDto : IMapFrom<CartItem>
{
    public ProductDto ProductObject { get; set; }
    public int Quantity { get; set; }
}