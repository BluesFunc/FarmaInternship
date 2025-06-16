using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

namespace Core.Application.Features.Commerce.ProductCategories.Queries.GetPaginatedProductCategories;

public record GetPaginatedProductCategoryCommand : GetPaginatedEntitiesCommand<ProductCategoryDto>
{
    public string? Name { get; set; }
}