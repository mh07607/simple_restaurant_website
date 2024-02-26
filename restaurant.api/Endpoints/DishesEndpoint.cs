using restaurant.api.Entities;
using restaurant.api.Repositories;
using restaurant.api.Dtos;

namespace restaurant.api.Endpoints;

public static class DishesEndpoint
{
    const string GetDishEndpointName = "GetDish";

    public static RouteGroupBuilder MapDishesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/dishes")
            .WithParameterValidation();

        group.MapGet("/", (IDishesRepository repository) => 
            repository.GetAll().Select(dish => dish.AsDto()));

        group.MapGet("/{id}", (IDishesRepository repository, int id) => {
            Dish? dish = repository.Get(id);
            
            return dish is not null? Results.Ok(dish.AsDto()) : Results.NotFound();
        })
        .WithName(GetDishEndpointName);

        group.MapPost("/", (IDishesRepository repository, CreateDishDto dishDto) => {
            Dish dish = dishDto.AsEntity();
            repository.Create(dish);
            return Results.CreatedAtRoute(GetDishEndpointName, new {id = dish.Id}, dish.AsDto());
        });

        group.MapPut("/{id}", (IDishesRepository repository, int id, UpdateDishDto updatedDishDto) => {
            Dish? existingDish = repository.Get(id);
            if(existingDish is null){
                return Results.NotFound();
                // string requestBody = JsonSerializer.Serialize(updatedDish);
                // using var client = new HttpClient();
                // var postResponse = client.PostAsync($"{app.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First()}/dishes", new StringContent(requestBody, Encoding.UTF8, "application/json")).Result;
                // // Forward the response
                // response.StatusCode = (int)postResponse.StatusCode;
                // response.ContentType = "application/json";
                // return postResponse.Content.ReadAsStringAsync().Result;
            }
            existingDish.Name = updatedDishDto.Name;
            existingDish.Price = updatedDishDto.Price;
            existingDish.ImageUri = updatedDishDto.ImageUri;
            existingDish.Type = updatedDishDto.Type;

            repository.Update(existingDish);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IDishesRepository repository, int id) => {
            Dish? existingDish = repository.Get(id);
            if(existingDish is not null){
                repository.Delete(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}