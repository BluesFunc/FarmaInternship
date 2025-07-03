using Core.Domain.Entities.Abstractions;
using Core.Domain.Enums.Trading;

namespace Core.Domain.Entities.Trading;

public class Cart : AuditableEntity
{
    public Guid UserId { get; private set; }
    public CartStatus Status { get; set; } = CartStatus.Active;
    public ICollection<CartItem> CartItems { get; private set; } = [];

    private Cart()
    {
    }

    public Cart(Guid userId)
    {
        UserId = userId;
    }
}