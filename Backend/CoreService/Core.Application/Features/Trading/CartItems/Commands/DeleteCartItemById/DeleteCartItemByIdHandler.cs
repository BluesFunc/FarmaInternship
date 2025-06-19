using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.CartItems.Commands.DeleteCartItemById;

public class DeleteCartItemByIdHandler :
    DeleteEntityByIdHandlerBase<ICartItemRepository, CartItem, DeleteCartItemByIdCommand, Result>
{
    public DeleteCartItemByIdHandler(IMapper mapper, ICartItemRepository repository) : base(mapper, repository)
    {
    }
}