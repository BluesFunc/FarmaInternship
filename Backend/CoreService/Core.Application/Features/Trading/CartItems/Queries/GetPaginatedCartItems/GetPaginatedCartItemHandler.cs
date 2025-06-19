using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.CartItems.Queries.GetPaginatedCartItems;

public class GetPaginatedCartItemHandler :
    GetPaginatedEntitiesHandlerBase<ICartItemRepository, CartItem, GetPaginatedCartItemsCommand, CartItemDto,
        CartItemQueryParams>
{
    public GetPaginatedCartItemHandler(IMapper mapper, ICartItemRepository repository) : base(mapper, repository)
    {
    }
}