using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(DbContext context)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactionRequest
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var result = await next(cancellationToken);

        if (result.IsSucceed)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        return result;
    }
}