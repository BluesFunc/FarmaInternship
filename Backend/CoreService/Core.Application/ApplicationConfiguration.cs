using System.Reflection;
using Core.Application.Behaviors;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMapster();
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            // Add behavior here. MediatR pipeline is placed like stack items
        });
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        return serviceCollection;
    }
}