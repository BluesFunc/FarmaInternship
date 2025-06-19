using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;

namespace Core.Application.Features.Trading.Carts.Commands.DeleteCartById;

public class DeleteCartByIdHandler :
    DeleteEntityByIdHandlerBase<ICartRepository, Cart, DeleteCartByIdCommand, Result>
{
    public DeleteCartByIdHandler(IMapper mapper, ICartRepository repository) : base(mapper, repository)
    {
    }
}