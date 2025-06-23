using Core.Application.Dtos.Commerce;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;

public record CreateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>, ITransactionRequest
{
    public required string Name { get; init; }
}