using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Models.QueryParams.Commerce;

namespace Core.Application.Features.Commerce.Products.Queries.GetPaginatedProducts;

public record GetPaginatedProductsCommand : GetPaginatedEntitiesCommand<ProductDto, ProductQueryParams>;