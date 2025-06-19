using Core.Domain.Entities.Commerce;
using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Mapster;

namespace Core.Application.Dtos.Trading;

public record CartDto : IMapFrom<Cart>
{
    public CartStatus Status { get; set; }
    public required IReadOnlyCollection<Product> Products { get; set; }
}