using Core.Domain.Enums.Trading;
using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Trading;

public record CartQueryParams : PaginationQueryParams
{
    public Guid? UserId { get; init; }
    public CartStatus? Status { get; init; }
}