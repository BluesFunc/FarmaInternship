using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

public abstract record GetPaginatedEntitiesCommand<TResponse> : IRequest<Result<PaginationList<TResponse>>>,
    ITransactionRequest
    where TResponse : notnull
{
    public int PageNo { get; init; }
    public int PageSize { get; init; }
}