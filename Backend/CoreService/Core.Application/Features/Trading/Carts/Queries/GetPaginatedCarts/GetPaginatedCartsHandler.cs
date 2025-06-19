using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.Carts.Queries.GetPaginatedCarts;

public class GetPaginatedCartsHandler :
    GetPaginatedEntitiesHandlerBase<ICartRepository, Cart,
        GetPaginatedCartsCommand,
        CartDto, CartQueryParams>
{
    public GetPaginatedCartsHandler(IMapper mapper, ICartRepository repository) : base(mapper, repository)
    {
    }
}