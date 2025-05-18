using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;

namespace Core.Domain.Entities.Trading;

public class CartItem : AuditableEntity
{
    public CartItem(Cart cart, Product product, int quantity = 1)
    {
        CartId = cart.Id;
        CartObject = cart;
        ProductObject = product;
        ProductId = product.Id;
        Quantity = quantity;
    }
    
    public Guid CartId { get; private set; }
    public Cart CartObject { get; private set; }
    public Guid ProductId { get; private set; }
    public Product ProductObject { get; private set; }
    public int Quantity { get; set; }

    
}