using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Models.QueryParams.Trading;

namespace Core.Application.Features.Trading.CartItems.Queries.GetPaginatedCartItems;

public record GetPaginatedCartItemsCommand : GetPaginatedEntitiesCommand<CartItemDto, CartItemQueryParams>;