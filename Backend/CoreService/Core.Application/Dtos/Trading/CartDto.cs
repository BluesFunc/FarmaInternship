using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Mapster;

namespace Core.Application.Dtos.Trading;

public record CartDto : IMapFrom<Cart>
{
    public Guid Id { get; set; }
    public CartStatus Status { get; set; }
    public required IReadOnlyCollection<CartItemDto> CartItems { get; set; }
}