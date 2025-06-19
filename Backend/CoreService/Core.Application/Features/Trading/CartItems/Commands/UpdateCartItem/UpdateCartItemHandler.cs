using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommand, Result<CartItemDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public UpdateCartItemHandler(ICartRepository cartRepository, IProductRepository productRepository,
        ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    public async Task<Result<CartItemDto>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartItemRepository.GetByIdAsync(request.CartItemId, cancellationToken);

        if (cartItem is null)
        {
            return Result<CartItemDto>.Failed(ErrorTypeCode.NotFound, $"CartItem not found");
        }

        if (cartItem.CartId != request.CartId)
        {
            var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);

            if (cart is null)
            {
                return Result<CartItemDto>.Failed(ErrorTypeCode.NotFound, $"Cart not found");
            }
        }

        if (cartItem.ProductId != request.ProductId)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product is null)
            {
                return Result<CartItemDto>
                    .Failed(ErrorTypeCode.NotFound, $"Product not found");
            }
        }

        cartItem.Quantity = request.Quantity;

        var data = _mapper.Map<CartItemDto>(cartItem);

        return Result<CartItemDto>.Successful(data);
    }
}