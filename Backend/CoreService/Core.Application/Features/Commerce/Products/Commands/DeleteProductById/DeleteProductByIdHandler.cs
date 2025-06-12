using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.Products.Commands.DeleteProductById;

public class DeleteProductByIdHandler :
    DeleteEntityByIdHandlerBase<IProductRepository, Product, DeleteProductByIdCommand, Result>
{
    public DeleteProductByIdHandler(IMapper mapper, IProductRepository repository) : base(mapper, repository)
    {
    }
}