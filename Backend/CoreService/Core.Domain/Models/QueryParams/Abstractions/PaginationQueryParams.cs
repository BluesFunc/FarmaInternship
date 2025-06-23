namespace Core.Domain.Models.QueryParams.Abstractions;

public abstract record PaginationQueryParams : FilterParams
{
    public int PageNo { get; set; } = 1;
    public int PageSize { get; init; } = 10;
}