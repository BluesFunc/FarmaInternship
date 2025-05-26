using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;

public record UpdateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
}