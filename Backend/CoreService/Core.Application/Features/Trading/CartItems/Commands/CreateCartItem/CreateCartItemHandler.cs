using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.CartItems.Commands.CreateCartItem;

public class CreateCartItemHandler : IRequestHandler<CreateCartItemCommand, Result<CartItemDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public CreateCartItemHandler(ICartRepository cartRepository, IProductRepository productRepository,
        ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    public async Task<Result<CartItemDto>> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);

        if (cart is null)
        {
            return Result<CartItemDto>.Failed(ErrorTypeCode.NotFound, $"Cart not found");
        }

        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            return Result<CartItemDto>
                .Failed(ErrorTypeCode.NotFound, $"Product not found");
        }

        var cartItem = new CartItem(cart, product, request.Quantity);
        var newEntity = await _cartItemRepository.AddAsync(cartItem, cancellationToken);

        if (newEntity is null)
        {
            return Result<CartItemDto>
                .Failed(ErrorTypeCode.EntityConflict, $"Entity conflict occurs");
        }

        var data = _mapper.Map<CartItemDto>(newEntity);

        return Result<CartItemDto>.Successful(data);
    }
}