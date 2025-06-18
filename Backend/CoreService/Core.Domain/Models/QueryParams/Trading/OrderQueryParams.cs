using Core.Domain.Enums.Trading;
using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Trading;

public record OrderQueryParams : PaginationQueryParams
{
    public Guid? UserId { get; init; }
    public Guid? CartId { get; init; }
    public OrderStatus? Status { get; init; }
    public decimal? TotalAmount { get; init; }
}