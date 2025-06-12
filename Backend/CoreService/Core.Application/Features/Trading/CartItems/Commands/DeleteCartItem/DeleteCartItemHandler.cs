using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.CartItems.Commands.DeleteCartItem;

public class DeleteCartItemHandler :
    DeleteEntityByIdHandlerBase<ICartItemRepository, CartItem, DeleteCartItemCommand, Result>
{
    public DeleteCartItemHandler(IMapper mapper, ICartItemRepository repository) : base(mapper, repository)
    {
    }
}