using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;

public abstract record CommandWithEntityId<TResponse> : IRequest<TResponse>
    where TResponse : Result
{
    public Guid Id { get; init; }
}