using Core.Domain.Entities.Commerce;
using Core.Domain.Entities.Trading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Trading;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable(EntityTablesName.CartItem);

        builder.HasKey(x => x.Id);

        builder.HasOne<Product>(x => x.ProductObject)
            .WithMany()
            .HasForeignKey(x => x.ProductId);

        builder.HasOne<Cart>(cartItem => cartItem.CartObject)
            .WithMany(cart => cart.CartItems)
            .HasForeignKey(cartItem => cartItem.CartId);
    }
}