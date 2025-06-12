using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;

public class CreateProductCategoryHandler :
    SingleRepositoryHandlerBase<IProductCategoryRepository, ProductCategory>,
    IRequestHandler<CreateProductCategoryCommand, Result<ProductCategoryDto>>
{
    public CreateProductCategoryHandler(IMapper mapper, IProductCategoryRepository repository)
        : base(mapper, repository)
    {
    }

    public async Task<Result<ProductCategoryDto>> Handle(CreateProductCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new ProductCategory() { Name = request.Name };

        var newEntity = await _repository.AddAsync(entity, cancellationToken);

        if (newEntity == null)
        {
            return Result<ProductCategoryDto>.Failed(ErrorTypeCode.EntityConflict);
        }

        var data = _mapper.Map<ProductCategoryDto>(newEntity);

        return Result<ProductCategoryDto>.Successful(data);
    }
}