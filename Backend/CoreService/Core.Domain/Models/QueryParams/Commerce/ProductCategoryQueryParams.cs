using Core.Domain.Enums.Commerce;
using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Commerce;

public record ProductCategoryQueryParams : PaginationQueryParams
{
    public string? Name { get; init; }
    public List<string>? CategoryName { get; init; }
    public decimal? Price { get; init; }
    public ProductStatus? Status { get; init; }
    public string? MerchantCompany { get; init; }
    public string? MerchantOrigin { get; init; }
}