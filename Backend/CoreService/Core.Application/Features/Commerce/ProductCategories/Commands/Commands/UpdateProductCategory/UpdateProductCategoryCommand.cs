using Core.Application.Dtos.Commerce;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;

public record UpdateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}