using Core.Domain.Entities.Commerce;
using Mapster;

namespace Core.Application.Dtos.Commerce;

public record MerchantDto : IMapFrom<Merchant>
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public Guid AdminId { get; init; }
}