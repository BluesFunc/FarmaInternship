using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Interfaces;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Products.Commands.DeleteProductById;

public record DeleteProductByIdCommand : CommandWithEntityId<Result>, ITransactionRequest;