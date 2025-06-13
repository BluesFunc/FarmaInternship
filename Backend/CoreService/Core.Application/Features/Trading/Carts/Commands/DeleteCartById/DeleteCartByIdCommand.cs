using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.Carts.Commands.DeleteCartById;

public record DeleteCartByIdCommand : CommandWithEntityId<Result>;