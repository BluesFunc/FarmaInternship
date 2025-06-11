using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.DeleteProductCategory;

public record DeleteProductCategoryByIdCommand : CommandWithEntityId<Result>;