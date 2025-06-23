using Core.Domain.Entities.Abstractions;
using Core.Domain.Enums.Commerce;

namespace Core.Domain.Entities.Commerce;

public class Product : AuditableEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ProductStatus Status { get; set; } = ProductStatus.OnPending;
    public Guid MedicineId { get; private set; }
    public Medicine MedicineItem { get; private set; }
    public Guid MerchantId { get; private set; }
    public Merchant MerchantCompany { get; private set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public IReadOnlyCollection<ProductCategory> Categories { get; private set; }

    private Product()
    {
    }

    public Product(string name, string description, Medicine medicineItem, Merchant merchant,
        decimal price, int stockQuantity)
    {
        Name = name;
        Description = description;
        SetMedicine(medicineItem);
        SetMerchant(merchant);
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void SetMedicine(Medicine medicine)
    {
        MedicineId = medicine.Id;
        MedicineItem = medicine;
    }

    public void SetMerchant(Merchant merchant)
    {
        MerchantId = merchant.Id;
        MerchantCompany = merchant;
    }
}