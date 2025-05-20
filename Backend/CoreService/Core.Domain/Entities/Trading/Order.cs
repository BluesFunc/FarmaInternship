using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Trading;

namespace Core.Domain.Entities.Trading;

public class Order : AuditableEntity
{
    public Order(Cart cart, decimal totalAmount)
    {
        CartObject = cart;
        CartId = cart.Id;
        TotalAmount = totalAmount;
    }

    public Guid CartId { get; init; }
    public Cart CartObject { get; init; }
    public decimal TotalAmount { get; init; }
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public IReadOnlyCollection<Product> Products { get; private set; }
}