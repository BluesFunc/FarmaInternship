using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Trading;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable(EntityTablesName.Cart);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasDefaultValue(CartStatus.Active);

        builder.HasMany(cart => cart.CartItems)
            .WithOne(cartItem => cartItem.CartObject)
            .HasForeignKey(cartItem => cartItem.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}