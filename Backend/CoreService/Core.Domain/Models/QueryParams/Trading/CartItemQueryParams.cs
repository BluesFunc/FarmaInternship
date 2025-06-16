using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Trading;

public record CartItemQueryParams : PaginationQueryParams
{
    public Guid? CartId { get; init; }
    public Guid? UserId { get; init; }
}