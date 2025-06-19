using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.Orders.Commands.DeleteOrderById;

public class DeleteOrderByIdHandler :
    DeleteEntityByIdHandlerBase<IOrderRepository, Order, DeleteOrderByIdCommand, Result>
{
    public DeleteOrderByIdHandler(IMapper mapper, IOrderRepository repository) : base(mapper, repository)
    {
    }
}