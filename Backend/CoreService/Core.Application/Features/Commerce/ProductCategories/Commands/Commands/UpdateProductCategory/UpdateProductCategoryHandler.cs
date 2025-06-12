using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;

public class UpdateProductCategoryHandler :
    SingleRepositoryHandlerBase<IProductCategoryRepository, ProductCategory>,
    IRequestHandler<UpdateProductCategoryCommand, Result<ProductCategoryDto>>
{
    public UpdateProductCategoryHandler(IMapper mapper, IProductCategoryRepository repository)
        : base(mapper, repository)
    {
    }

    public async Task<Result<ProductCategoryDto>> Handle(UpdateProductCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            return Result<ProductCategoryDto>
                .Failed(ErrorTypeCode.NotFound);
        }

        entity.Name = request.Name;
        var data = _mapper.Map<ProductCategoryDto>(entity);
        return Result<ProductCategoryDto>.Successful(data);
    }
}