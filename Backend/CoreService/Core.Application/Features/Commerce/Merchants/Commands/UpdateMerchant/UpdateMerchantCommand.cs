using Core.Application.Dtos.Commerce;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;

public class UpdateMerchantCommand : IRequest<Result<MerchantDto>>, ITransactionRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
}