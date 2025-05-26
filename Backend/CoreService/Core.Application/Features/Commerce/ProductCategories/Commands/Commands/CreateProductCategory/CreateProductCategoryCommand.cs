using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;

public record CreateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>
{
    public string Name { get; init; } = null!;
}