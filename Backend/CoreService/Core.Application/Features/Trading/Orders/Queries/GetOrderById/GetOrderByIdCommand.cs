using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Trading.Orders.Queries.GetOrderById;

public record GetOrderByIdCommand : CommandWithEntityId<Result<OrderDto>>;