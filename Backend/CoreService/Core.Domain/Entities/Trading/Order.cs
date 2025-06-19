using Core.Domain.Entities.Abstractions;
using Core.Domain.Enums.Trading;

namespace Core.Domain.Entities.Trading;

public class Order : AuditableEntity
{
    public Guid UserId { get; init; }
    public Guid CartId { get; init; }
    public Cart CartObject { get; init; }
    public decimal TotalAmount { get; init; }
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public ICollection<OrderItem> OrderItems { get; private set; }
    
    private Order(){}

    public Order(Cart cart, Guid userId)
    {
        UserId = userId;
        CartObject = cart;
        CartId = cart.Id;
    }

    public void SetOrderItem(ICollection<OrderItem> orderItems)
    {
        OrderItems = orderItems;
    }
}