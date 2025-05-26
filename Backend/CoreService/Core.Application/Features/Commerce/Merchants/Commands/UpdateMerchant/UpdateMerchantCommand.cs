using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;

public class UpdateMerchantCommand : IRequest<Result<MerchantDto>>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
}