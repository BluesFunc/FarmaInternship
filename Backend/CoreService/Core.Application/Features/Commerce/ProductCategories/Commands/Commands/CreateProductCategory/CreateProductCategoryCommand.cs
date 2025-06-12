using Core.Application.Dtos.Commerce;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;

public record CreateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>
{
    public required string Name { get; init; }
}