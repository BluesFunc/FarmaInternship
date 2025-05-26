using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Products.Commands.DeleteProductById;

public record DeleteProductByIdCommand : CommandWithEntityId<Result>;