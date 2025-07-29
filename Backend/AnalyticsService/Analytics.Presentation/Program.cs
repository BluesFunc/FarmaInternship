using Analytics.BLL;
using Analytics.BLL.Services;
using Analytics.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .ConfigureBusinessLogicLayer()
    .ConfigureDal()
    .AddGrpc();


var app = builder.Build();

app.MapGrpcService<OrderStatisticService>();


await app.RunAsync();