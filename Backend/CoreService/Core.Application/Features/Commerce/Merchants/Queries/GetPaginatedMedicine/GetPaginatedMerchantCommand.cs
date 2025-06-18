using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

namespace Core.Application.Features.Commerce.Merchants.Queries.GetPaginatedMedicine;

public record GetPaginatedMerchantCommand : GetPaginatedEntitiesCommand<MerchantDto>
{
}