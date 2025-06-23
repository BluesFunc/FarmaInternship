using Core.Domain.Entities.Commerce;
using Core.Domain.EntitiesConstraints.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Commerce;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable(EntityTablesName.ProductCategory);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(ProductCategoryConstraint.MaxNameLength)
            .IsRequired();
    }
}