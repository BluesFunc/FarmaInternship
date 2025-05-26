using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using FluentValidation;
using MediatR;

namespace Core.Application.Behaviors;

public class ValidationBehavior<TRequset, TResponse> : IPipelineBehavior<TRequset, TResponse>
    where TRequset : notnull
    where TResponse : Result
{
    private IEnumerable<IValidator<IRequest>> Validators { get; init; }

    public ValidationBehavior(IEnumerable<IValidator<IRequest>> validators)
    {
        Validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequset request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!Validators.Any()) return await next();

        var context = new ValidationContext<TRequset>(request);
        var validationResults = await Task.WhenAll(
            Validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .Select(r => r.ErrorMessage)
            .ToList();

        if (failures.Count == 0) return await next();

        var message = string.Join(" ", failures);
        return ToResultResponse<TResponse>(message, ErrorTypeCode.ValidationError);
    }

    private static TResponseType ToResultResponse<TResponseType>(string message, ErrorTypeCode code)
        where TResponseType : Result
    {
        if (typeof(TResponseType) == typeof(Result)) return (TResponseType)Result.Failed(code, message);

        var result = typeof(Result<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResponseType).GenericTypeArguments[0])
            .GetMethods()
            .First(m => m.Name.Equals(nameof(Result.Failed)))
            .Invoke(null, [message, code])!;

        return (TResponseType)result;
    }
}