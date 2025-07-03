using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Models.QueryParams.Trading;

namespace Core.Application.Features.Trading.Carts.Queries.GetPaginatedCarts;

public record GetPaginatedCartsCommand : GetPaginatedEntitiesCommand<CartDto, CartQueryParams>;