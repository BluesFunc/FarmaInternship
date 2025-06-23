using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Trading;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(EntityTablesName.Order);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasDefaultValue(OrderStatus.New);

        builder.HasOne<Cart>(x => x.CartObject)
            .WithOne();

        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.OrderObject)
            .HasForeignKey(x => x.OrderId);
    }
}