using Core.Application.Dtos.Commerce;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Products.Commands.CreateProduct;

public class CreateProductHandler :
    IRequestHandler<CreateProductCommand, Result<ProductDto>>

{
    private IMerchantRepository _merchantRepository;
    private IMedicineRepository _medicineRepository;
    private IProductRepository _productRepository;
    private IMapper _mapper;

    public CreateProductHandler(
        IMerchantRepository merchantRepository,
        IMedicineRepository medicineRepository,
        IProductRepository productRepository,
        IMapper mapper
    )
    {
        _merchantRepository = merchantRepository;
        _medicineRepository = medicineRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var medicine = await _medicineRepository.GetByIdAsync(request.MedicineId, cancellationToken);

        if (medicine is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }

        var merchant = await _merchantRepository.GetByIdAsync(request.MerchantId, cancellationToken);

        if (merchant is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }

        var product = new Product(
            request.Name,
            request.Description,
            medicine,
            merchant,
            request.Price,
            request.StockQuantity
        )
        {
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Status = ProductStatus.OnPending
        };

        var entity = await _productRepository.AddAsync(product, cancellationToken);

        if (entity is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.EntityConflict);
        }

        var data = _mapper.Map<ProductDto>(entity);

        return Result<ProductDto>.Successful(data);
    }
}