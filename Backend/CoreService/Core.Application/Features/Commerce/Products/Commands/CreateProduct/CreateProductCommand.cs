using Core.Application.Dtos.Commerce;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using MediatR;

namespace Core.Application.Features.Commerce.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<Result<ProductDto>>
{
    public required string Name { get; init; } 
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public Guid MedicineId { get; init; }
    public Guid MerchantId { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
}