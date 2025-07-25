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
    .ConfigureDal()
    .AddGrpc();



var app = builder.Build();

app.MapGrpcService<OrderStatisticService>();

app.MapPost("/users", async (UserService collection) =>
{
    var user = new UserStatistic(new Guid());

    await collection.Collection.InsertOneAsync(user);
    return Results.Json(user);
});

app.MapGet("/users", async (UserService collection) =>
{
   
    var result = await collection.Collection.FindAsync(statistic => true);

    return await result.ToListAsync();
});



app.MapGet("/users/{id:guid}", async (UserService collection, Guid id) =>
{
    var user = await collection.Collection.FindAsync(x => x.UserId == id);
    return Results.Json(await user.FirstAsync());
});

app.Run();

