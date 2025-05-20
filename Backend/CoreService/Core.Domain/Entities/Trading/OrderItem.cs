using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;

namespace Core.Domain.Entities.Trading;

public class OrderItem : AuditableEntity
{
    public OrderItem(Order orderObject, Product productObject, int quantity, decimal priceAtOrder)
    {
        OrderId = orderObject.Id;
        OrderObject = orderObject;
        ProductId = productObject.Id;
        ProductObject = productObject;
        Quantity = quantity;
        PriceAtOrder = priceAtOrder;
    }

    public Guid OrderId { get; init; }
    public Order OrderObject { get; init; }
    public Guid ProductId { get; init; }
    public Product ProductObject { get; init; }
    public int Quantity { get; set; }
    public decimal PriceAtOrder { get; set; }
}