using Core.Domain.Enums.Commerce;
using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Commerce;

public record ProductQueryParams : PaginationQueryParams
{
    public string? Name { get; init; }
    public ProductStatus? Status { get; init; }
}