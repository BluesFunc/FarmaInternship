using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.DeleteProductCategory;

public class DeleteProductCategoryHandler :
    DeleteEntityByIdHandlerBase<IProductCategoryRepository, ProductCategory, Result>
{
    public DeleteProductCategoryHandler(IMapper mapper, IProductCategoryRepository repository) : base(mapper,
        repository)
    {
    }
}