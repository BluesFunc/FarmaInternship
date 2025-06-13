using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.Carts.Queries.GetCartById;

public record GetCartByIdCommand : CommandWithEntityId<Result<CartDto>>;