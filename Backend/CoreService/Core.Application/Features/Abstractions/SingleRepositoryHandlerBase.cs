using Core.Domain.Entities.Abstractions;
using Core.Domain.Interfaces.Repositories;
using MapsterMapper;

namespace Core.Application.Features.Abstractions;

public abstract class SingleRepositoryHandlerBase
    <TRepository, TEntity>
    where TRepository : IGenericRepository<TEntity>
    where TEntity : Entity
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;

    public SingleRepositoryHandlerBase(IMapper mapper, TRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }
}