using Core.Domain.Entities.Trading;
using Core.Domain.Models.QueryParams.Trading;

namespace Core.Domain.Interfaces.Repositories.Trading;

public interface ICartRepository : IFilteredRepository<CartQueryParams, Cart>;