using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;

namespace Core.Domain.Entities.Trading;

public class CartItem : AuditableEntity
{
    public Guid CartId { get; private set; }
    public Cart CartObject { get; private set; }
    public Guid ProductId { get; private set; }
    public Product ProductObject { get; private set; }
    public int Quantity { get; set; }

    private CartItem()
    {
    }

    public CartItem(Cart cart, Product product, int quantity = 1)
    {
        CartId = cart.Id;
        CartObject = cart;
        ProductObject = product;
        ProductId = product.Id;
        Quantity = quantity;
    }

    public void SetProduct(Product product)
    {
        ProductObject = product;
        ProductId = product.Id;
    }

    public void SetCart(Cart cart)
    {
        CartObject = cart;
        CartId = cart.Id;
    }
}