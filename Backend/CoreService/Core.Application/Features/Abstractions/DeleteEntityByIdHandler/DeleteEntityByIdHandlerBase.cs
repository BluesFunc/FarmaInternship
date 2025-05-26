using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Abstractions.DeleteEntityByIdHandler;

public abstract class DeleteEntityByIdHandlerBase<TRepository, TEntity, TResponse> :
    SingleRepositoryHandlerBase<TRepository, TEntity>,
    IRequestHandler<CommandWithEntityId<TResponse>, TResponse>
    where TRepository : IGenericRepository<TEntity>
    where TEntity : Entity
    where TResponse : Result
{
    public DeleteEntityByIdHandlerBase(IMapper mapper, TRepository repository) : base(mapper, repository)
    {
    }


    public async Task<TResponse> Handle(CommandWithEntityId<TResponse> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            return (TResponse)Result.Failed(ErrorTypeCode.NotFound, "Entity does not exist");
        }

        var isRemoved = _repository.Delete(entity);
        return !isRemoved
            ? (TResponse)Result.Failed(ErrorTypeCode.EntityConflict, "Can not delete entity")
            : (TResponse)Result.Successful("Successfully removed");
    }
}