using Core.Application.Dtos.Commerce;
using Core.Application.Requirements.ResourceAuth;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Commerce.Products.Commands.UpdateProduct;

public class UpdateProductHandler :
    IRequestHandler<UpdateProductCommand, Result<ProductDto>>
{
    private IMerchantRepository _merchantRepository;
    private IMedicineRepository _medicineRepository;
    private IProductRepository _productRepository;
    private IMapper _mapper;
    private HttpContext _httpContext;
    private IAuthorizationService _authorizationService;

    public UpdateProductHandler(
        IMerchantRepository merchantRepository,
        IMedicineRepository medicineRepository,
        IProductRepository productRepository,
        IMapper mapper, IAuthorizationService authorizationService, IHttpContextAccessor contextAccessor)
    {
        _merchantRepository = merchantRepository;
        _medicineRepository = medicineRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _httpContext = contextAccessor.HttpContext;
    }

    public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var merchant = await _merchantRepository.GetByIdAsync(request.MerchantId, cancellationToken);

        if (merchant is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }

        var user = _httpContext.User;

        var authorizeResult =
            await _authorizationService.AuthorizeAsync(user, merchant, ResourcePolicies.ProductModification);

        if (!authorizeResult.Succeeded)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.AuthorizationError);
        }

        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }


        var medicine = await _medicineRepository.GetByIdAsync(request.MedicineId, cancellationToken);

        if (medicine is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }


        product.Name = product.Name;
        product.Description = request.Description ?? product.Description;
        product.ImageUrl = request.ImageUrl ?? product.ImageUrl;
        product.SetMerchant(merchant);
        product.SetMedicine(medicine);
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;

        var updatedProduct = _productRepository.Update(product);

        var data = _mapper.Map<ProductDto>(updatedProduct);
        return Result<ProductDto>.Successful(data);
    }
}