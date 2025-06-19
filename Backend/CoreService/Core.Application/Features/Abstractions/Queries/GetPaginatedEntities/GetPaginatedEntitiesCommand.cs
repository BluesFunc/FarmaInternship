using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

public abstract record GetPaginatedEntitiesCommand<TResponse> : IRequest<Result<PaginationList<TResponse>>>
    where TResponse : notnull
{
    public int PageNo { get; init; }
    public int PageSize { get; init; }
}