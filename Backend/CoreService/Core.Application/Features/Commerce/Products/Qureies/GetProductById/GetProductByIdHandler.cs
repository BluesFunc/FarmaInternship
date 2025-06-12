using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Products.Qureies.GetProductById;

public class GetProductByIdHandler :
    SingleRepositoryHandlerBase<IProductRepository, Product>
    , IRequestHandler<GetProductByIdCommand, Result<ProductDto>>
{
    public GetProductByIdHandler(IMapper mapper, IProductRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<ProductDto>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }

        var data = _mapper.Map<ProductDto>(entity);

        return Result<ProductDto>.Successful(data);
    }
}