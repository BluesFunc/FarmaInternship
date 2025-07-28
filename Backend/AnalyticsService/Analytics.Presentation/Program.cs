using Analytics.BLL;
using Analytics.BLL.Services;
using Analytics.DAL;
using Analytics.DAL.Collections;
using Analytics.DAL.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .ConfigureBusinessLogicLayer()
    .ConfigureDal()
    .AddGrpc();



var app = builder.Build();

app.MapGrpcService<OrderStatisticService>();


app.MapPost("/users", async (IRepository<UserStatistic> collection) =>
{
    var user = new UserStatistic(new Guid());

    await collection.AddModelAsync(user);
    return Results.Json(user);
});

app.MapGet("/users", async (IRepository<UserStatistic> service) =>
{
   
    var result = await service.GetModelsByFilterAsync(x => true);

    return result;
});



app.MapGet("/users/{id:guid}", async (IRepository<UserStatistic> collection, Guid id) =>
{
    var user = await collection.GetModelByIdAsync(id);
    return Results.Json(user);
});

await app.RunAsync();

