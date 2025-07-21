using Analytics.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();


var app = builder.Build();

app.MapGrpcService<OrderStatisticService>();

app.Run();