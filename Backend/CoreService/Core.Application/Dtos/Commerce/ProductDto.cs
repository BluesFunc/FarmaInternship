using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Mapster;

namespace Core.Application.Dtos.Commerce;

public class ProductDto : IMapFrom<Product>
{
    public required  string Name { get; init; } 
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public ProductStatus Status { get; init; }
    public required  Medicine MedicineItem { get; init; } 
    public required  Merchant MerchantCompany { get; init; } 
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public required  IReadOnlyCollection<ProductCategory> Categories { get; init; } 
}