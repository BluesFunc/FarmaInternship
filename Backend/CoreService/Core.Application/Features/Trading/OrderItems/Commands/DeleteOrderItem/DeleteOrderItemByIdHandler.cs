using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.OrderItems.Commands.DeleteOrderItem;

public class DeleteOrderItemByIdHandler : 
    DeleteEntityByIdHandlerBase<IOrderItemRepository, OrderItem, DeleteOrderItemByIdCommand, Result>
{
    public DeleteOrderItemByIdHandler(IMapper mapper, IOrderItemRepository repository) : base(mapper, repository)
    {
    }
}