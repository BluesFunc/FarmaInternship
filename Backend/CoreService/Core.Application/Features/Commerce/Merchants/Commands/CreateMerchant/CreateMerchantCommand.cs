using Core.Application.Dtos.Commerce;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;

public record CreateMerchantCommand : IRequest<Result<MerchantDto>>, ITransactionRequest
{
    public required string Name { get; init; }
    public string Description { get; init; } = "Merchant description";
    public Guid AdminId { get; init; }
}