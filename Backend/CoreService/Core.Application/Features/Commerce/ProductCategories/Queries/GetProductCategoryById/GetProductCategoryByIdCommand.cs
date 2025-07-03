using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Interfaces;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.ProductCategories.Queries.GetProductCategoryById;

public record GetProductCategoryByIdCommand : CommandWithEntityId<Result<ProductCategoryDto>>, ITransactionRequest;