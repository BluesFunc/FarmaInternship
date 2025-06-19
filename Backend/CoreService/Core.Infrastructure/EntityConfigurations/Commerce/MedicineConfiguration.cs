using Core.Domain.Entities.Commerce;
using Core.Domain.EntitiesConstraints.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EntityConfigurations.Commerce;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable(EntityTablesName.Medicine);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(MedicineConstraint.MaxNameLength)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.MeasureUnit)
            .IsRequired();
        
        builder.Property(x => x.Volume)
            .IsRequired();

        builder.Property(x => x.ManufacturerName)
            .HasMaxLength(MedicineConstraint.MaxManufacterNameLength)
            .IsRequired();

        builder.Property(x => x.ManufacturerOrigin)
            .HasMaxLength(MedicineConstraint.MaxManufacterOriginLength)
            .IsRequired();
        
        builder.HasMany(medicine => medicine.ProductItem)
            .WithOne(product => product.MedicineItem)
            .HasForeignKey(product => product.MedicineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}