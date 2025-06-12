using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Products.Qureies.GetProductById;

public record GetProductByIdCommand : CommandWithEntityId<Result<ProductDto>>;