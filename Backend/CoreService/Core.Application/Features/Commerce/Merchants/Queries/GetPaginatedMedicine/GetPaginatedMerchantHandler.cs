using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.Merchants.Queries.GetPaginatedMedicine;

public class GetPaginatedMerchantHandler :
    GetPaginatedEntitiesHandlerBase<IMerchantRepository, Merchant, GetPaginatedMerchantCommand, MerchantDto,
        MerchantQueryParams>
{
    public GetPaginatedMerchantHandler(IMapper mapper, IMerchantRepository repository) : base(mapper, repository)
    {
    }
}