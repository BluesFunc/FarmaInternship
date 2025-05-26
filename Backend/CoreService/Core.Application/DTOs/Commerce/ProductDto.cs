using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Mapster;

namespace Core.Application.DTOs.Commerce;

public class ProductDto : IMapFrom<Product>
{
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public ProductStatus Status { get; init; }
    public Medicine MedicineItem { get; init; } = null!;
    public Merchant MerchantCompany { get; init; } = null!;
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public IReadOnlyCollection<ProductCategory> Categories { get; init; } = null!;
}