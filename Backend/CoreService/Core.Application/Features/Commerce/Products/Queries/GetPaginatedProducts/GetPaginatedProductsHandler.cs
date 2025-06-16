using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.Products.Queries.GetPaginatedProducts;

public class GetPaginatedProductsHandler
    : GetPaginatedEntitiesHandlerBase<IProductRepository, Product, GetPaginatedProductsCommand, ProductDto,
        ProductQueryParams>
{
    public GetPaginatedProductsHandler(IMapper mapper, IProductRepository repository) : base(mapper, repository)
    {
    }
}