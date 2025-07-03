using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Models.QueryParams.Commerce;

namespace Core.Application.Features.Commerce.ProductCategories.Queries.GetPaginatedProductCategories;

public record
    GetPaginatedProductCategoryCommand : GetPaginatedEntitiesCommand<ProductCategoryDto, ProductCategoryQueryParams>
{
    public string? Name { get; set; }
}