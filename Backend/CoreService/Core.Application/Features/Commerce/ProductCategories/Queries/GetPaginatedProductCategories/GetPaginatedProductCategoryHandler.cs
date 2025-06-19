using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.ProductCategories.Queries.GetPaginatedProductCategories;

public class GetPaginatedProductCategoryHandler :
    GetPaginatedEntitiesHandlerBase<IProductCategoryRepository,
        ProductCategory, GetPaginatedProductCategoryCommand,
        ProductCategoryDto, ProductCategoryQueryParams>
{
    public GetPaginatedProductCategoryHandler(IMapper mapper, IProductCategoryRepository repository) : base(mapper,
        repository)
    {
    }
}