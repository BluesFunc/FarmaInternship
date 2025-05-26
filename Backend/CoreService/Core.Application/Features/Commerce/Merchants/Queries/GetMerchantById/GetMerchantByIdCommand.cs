using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Merchants.Queries.GetMerchantById;

public record GetMerchantByIdCommand : CommandWithEntityId<Result<MerchantDto>>
{
}