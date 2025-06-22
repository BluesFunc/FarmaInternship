using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Infrastructure.Contexts;
using Core.Infrastructure.Handlers.Repositories.Commerce;
using Core.Infrastructure.Handlers.Repositories.Trading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class DatabaseInjection
{
    private const string DatabaseEnvironmentName = "CONNECTION_STRING";

    public static IServiceCollection InjectDatabase(this IServiceCollection service)
    {
        service.AddDbContext<DbContext, ApplicationDbContext>(option =>
        {
            option.UseNpgsql(Environment.GetEnvironmentVariable(DatabaseEnvironmentName));
        });

        service.AddScoped<IMerchantRepository, MerchantRepository>();
        service.AddScoped<IMedicineRepository, MedicineRepository>();
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        service.AddScoped<IOrderRepository, OrderRepository>();
        service.AddScoped<IOrderItemRepository, OrderItemRepository>();
        service.AddScoped<ICartRepository, CartRepository>();
        service.AddScoped<ICartItemRepository, CartItemRepository>();

        return service;
    }
}