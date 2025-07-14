using Core.Application.Interfaces;
using Core.Application.Wrappers;
using Core.Domain.Models.QueryParams.Abstractions;
using MediatR;

namespace Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

public abstract record GetPaginatedEntitiesCommand<TResponse, TFilter>
    : IRequest<Result<PaginationList<TResponse>>>,
        ITransactionRequest
    where TResponse : notnull
    where TFilter : PaginationQueryParams, new()
{
    public required TFilter Filter { get; init; } = new() { PageNo = 1, PageSize = 5 };
}