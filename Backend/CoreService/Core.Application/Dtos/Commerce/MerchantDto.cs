using Core.Domain.Entities.Commerce;
using Mapster;

namespace Core.Application.Dtos.Commerce;

public record MerchantDto : IMapFrom<Merchant>
{
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public Guid AdminId { get; init; }
}