using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Commerce;

public record MerchantQueryParams : PaginationQueryParams
{
    public string? Name { get; init; }
}