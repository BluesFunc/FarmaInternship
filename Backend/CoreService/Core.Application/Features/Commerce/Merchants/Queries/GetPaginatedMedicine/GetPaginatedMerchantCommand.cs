using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Models.QueryParams.Commerce;

namespace Core.Application.Features.Commerce.Merchants.Queries.GetPaginatedMedicine;

public record GetPaginatedMerchantCommand : GetPaginatedEntitiesCommand<MerchantDto, MerchantQueryParams>
{
}