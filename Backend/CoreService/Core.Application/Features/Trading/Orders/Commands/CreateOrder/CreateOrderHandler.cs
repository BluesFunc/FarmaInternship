using Core.Application.Dtos.Trading;
using Core.Application.Interfaces;
using Core.Application.Interfaces.Statistics;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Application.Features.Trading.Orders.Commands.CreateOrder;

public class CreateOrderHandler :
    IRequestHandler<CreateOrderCommand, Result<OrderDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IStatisticMessageProducer _messageProducer;
    private readonly IOrderNotificationService _notificationService;
    private readonly ILogger<CreateOrderHandler> _logger;

    public CreateOrderHandler(ICartRepository cartRepository, IOrderRepository orderRepository, IMapper mapper,
        IStatisticMessageProducer messageProducer, IOrderNotificationService notificationService,
        ILogger<CreateOrderHandler> logger)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
        //    _messageProducer = messageProducer;
        _notificationService = notificationService;
        _logger = logger;
    }


    public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);

        if (cart is null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.NotFound);
        }

        var order = new Order(cart, request.UserId);

        order.SetOrderItem(CreateOrderItems(order, cart.CartItems));
        var newOrder = await _orderRepository.AddAsync(order, cancellationToken);

        _cartRepository.Update(cart);
        if (newOrder is null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.EntityConflict);
        }


        var data = _mapper.Map<OrderDto>(newOrder);

        await _notificationService.SendNotification(request.UserId, $"Your order {order.Id} is created");

        // try
        // {
        //     var userStatisticMessage = new UserStatisticMessage()
        //         { UserId = request.UserId, OrderCreated = 1, TotalRevenue = (ulong)data.TotalAmount };
        //     var userJsonMessage = JsonSerializer.Serialize(userStatisticMessage, JsonSerializerOptions.Default);
        //
        //     await _messageProducer.SendMessageAsync(StatisticBrokerConfiguration.UserTopic, userJsonMessage,
        //         cancellationToken);
        // }
        // catch (Exception ex)
        // {
        //     _logger.LogError($"Kafka brokers do not receive message {order.Id} creation");
        // }


        return Result<OrderDto>.Successful(data);
    }

    private IList<OrderItem> CreateOrderItems(Order order, ICollection<CartItem> cartItems)
    {
        var items = cartItems.Select(x =>
                new OrderItem(order, x.ProductObject, x.Quantity, x.Quantity * x.ProductObject.Price))
            .ToList();

        return items;
    }
}