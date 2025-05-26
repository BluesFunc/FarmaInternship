using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<Result<ProductDto>>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public Guid MedicineId { get; init; }
    public Guid MerchantId { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
}