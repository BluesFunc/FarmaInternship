using Core.Application.Dtos.Commerce;
using Core.Domain.Entities.Commerce;
using Core.Domain.EntitiesConstraints.Commerce;
using Core.Domain.Enums.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Commerce;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(EntityTablesName.Product);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(ProductConstraint.MaxNameLength)
            .IsRequired();

        builder.Property(p => p.StockQuantity)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.Status)
            .HasDefaultValue(ProductStatus.OnPending);

        builder.HasMany(product => product.Categories)
            .WithMany(category => category.Products);
        
    }
}