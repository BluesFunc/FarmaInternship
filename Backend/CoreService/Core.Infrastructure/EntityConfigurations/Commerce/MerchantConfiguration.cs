using Core.Domain.Entities.Commerce;
using Core.Domain.EntitiesConstraints.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Commerce;

public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
{
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable(EntityTablesName.Merchant);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(MerchantConstraint.MaxNameLength)
            .IsRequired();

        builder.HasIndex(m => m.Name).IsUnique();

        builder.Property(x => x.AdminId)
            .IsRequired();

        builder.HasMany(merchant => merchant.Products)
            .WithOne(product => product.MerchantCompany)
            .HasForeignKey(product => product.MerchantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}