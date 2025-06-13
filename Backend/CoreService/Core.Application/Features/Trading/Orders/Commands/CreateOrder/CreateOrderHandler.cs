using Core.Application.Dtos.Trading;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.Orders.Commands.CreateOrder;

public class CreateOrderHandler :
    IRequestHandler<CreateOrderCommand, Result<OrderDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;


    public CreateOrderHandler(ICartRepository cartRepository, IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);

        if (cart is null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.NotFound);
        }

        var order = new Order(cart);

        var orderItems = CreateOrderItems(order, cart.CartItems);
        
        var newOrder = await _orderRepository.AddAsync(order, cancellationToken);

        if (newOrder is null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.EntityConflict);
        }

        var data = _mapper.Map<OrderDto>(newOrder);

        return Result<OrderDto>.Successful(data);
    }

    private IList<OrderItem> CreateOrderItems(Order order, ICollection<CartItem> cartItems)
    {
        IList<OrderItem> orderItems = [];

        foreach (var item in cartItems)
        {
            var priceAtOrder = item.Quantity * item.ProductObject.Price;
            var orderItem = new OrderItem(order, item.ProductObject, item.Quantity, priceAtOrder);
            orderItems.Add(orderItem); // LINQ  
        }

        return orderItems;
    }
}