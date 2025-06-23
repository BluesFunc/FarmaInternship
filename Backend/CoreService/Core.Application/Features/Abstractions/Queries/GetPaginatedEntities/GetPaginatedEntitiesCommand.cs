using Core.Application.Interfaces;
using Core.Application.Wrappers;
using Core.Domain.Models.QueryParams.Abstractions;
using MediatR;

namespace Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

public abstract record GetPaginatedEntitiesCommand<TResponse, TFilter>
    : IRequest<Result<PaginationList<TResponse>>>,
        ITransactionRequest
    where TResponse : notnull
    where TFilter : FilterParams
{
    public int PageNo { get; init; } = 1;
    public int PageSize { get; init; } = 5;
    public TFilter? Filter { get; init; }
}