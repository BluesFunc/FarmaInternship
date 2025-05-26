using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;

public record CreateMerchantCommand : IRequest<Result<MerchantDto>>
{
    public string Name { get; init; } = null!;
    public string Description { get; init; } = "Merchant description";
    public Guid AdminId { get; init; }
}