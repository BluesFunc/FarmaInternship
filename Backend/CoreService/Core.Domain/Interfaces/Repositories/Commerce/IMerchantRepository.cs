using Core.Domain.Entities.Commerce;
using Core.Domain.Models.QueryParams.Commerce;

namespace Core.Domain.Interfaces.Repositories.Commerce;

public interface IMerchantRepository : IFilteredRepository<MerchantQueryParams, Merchant>;