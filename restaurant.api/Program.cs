using restaurant.api.Endpoints;
using restaurant.api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDishesRepository, InMemDishesRepository>();

var app = builder.Build();

app.MapDishesEndpoints();

app.Run();
