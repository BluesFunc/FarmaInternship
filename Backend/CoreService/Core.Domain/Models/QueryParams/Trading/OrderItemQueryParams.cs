using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Trading;

public record OrderItemQueryParams : PaginationQueryParams
{
    public Guid? ProductId { get; init; }
    public Guid? OrderId { get; init; }
}