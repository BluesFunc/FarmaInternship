using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models.QueryParams.Abstractions;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

public abstract class GetPaginatedEntitiesHandlerBase<TRepository, TEntity, TRequest, TResponse, TFilter> :
    SingleRepositoryHandlerBase<TRepository, TEntity>
    , IRequestHandler<TRequest, Result<PaginationList<TResponse>>>
    where TRepository : IFilteredRepository<TFilter, TEntity>
    where TEntity : Entity
    where TRequest : GetPaginatedEntitiesCommand<TResponse, TFilter>
    where TResponse : notnull
    where TFilter : PaginationQueryParams, new()
{
    protected GetPaginatedEntitiesHandlerBase(IMapper mapper, TRepository repository) : base(mapper, repository)
    {
    }


    public async Task<Result<PaginationList<TResponse>>> Handle(TRequest request, CancellationToken cancellationToken = default)
    {
        var filter = request.Filter.Adapt<TFilter>();

        var entities = await _repository.GetPaginatedAsync(filter, cancellationToken);

        if (entities is null)
        {
            return Result<PaginationList<TResponse>>.Failed(ErrorTypeCode.EntityConflict);
        }

        var data = _mapper.Map<IReadOnlyList<TResponse>>(entities);
        var paginationList = new PaginationList<TResponse>(data, request.Filter.PageNo, request.Filter.PageSize);


        return Result<PaginationList<TResponse>>.Successful(paginationList);
    }
}