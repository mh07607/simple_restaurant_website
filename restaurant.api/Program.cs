using System.Text.Json;
using restaurant.api.Entities;

const string GetDishEndpointName = "GetDish";

List<Dish> dishes = new(){
    new Dish(){
        Id = 0,
        Name = "Biryani",
        Type = "Desi",
        Price = 149.99M,
        ImageUri = "https://placehold.co/100"
        // ImageUri = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/%22Hyderabadi_Dum_Biryani%22.jpg/800px-%22Hyderabadi_Dum_Biryani%22.jpg"
    }, 
    new Dish(){
        Id = 1,
        Name = "Pulao",
        Type = "Desi",
        Price = 199.99M,
        ImageUri = "https://placehold.co/100"
        // ImageUri = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/%22Hyderabadi_Dum_Biryani%22.jpg/800px-%22Hyderabadi_Dum_Biryani%22.jpg"
    }, 
    new Dish(){
        Id = 2,
        Name = "Zinger Burger",
        Type = "Burger",
        Price = 249.99M,
        ImageUri = "https://placehold.co/100"
        // ImageUri = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/%22Hyderabadi_Dum_Biryani%22.jpg/800px-%22Hyderabadi_Dum_Biryani%22.jpg"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/dishes", () => dishes);

app.MapGet("/dishes/{id}", (int id) => {
    Dish? dish = dishes.Find(dish => dish.Id == id);
    if(dish is null){
        return Results.NotFound();
    }
    return Results.Ok(dish);
})
.WithName(GetDishEndpointName);

app.MapPost("/dishes", (Dish dish) => {
    dish.Id = dishes.Max(dish => dish.Id) + 1;
    dishes.Add(dish);

    return Results.CreatedAtRoute(GetDishEndpointName, new {id = dish.Id}, dish);
});

app.MapPut("/dishes/{id}", (int id, Dish updatedDish) => {
    Dish? existingDish = dishes.Find(dish => dish.Id == id);
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
    
    existingDish.Name = updatedDish.Name;
    existingDish.Price = updatedDish.Price;
    existingDish.ImageUri = updatedDish.ImageUri;
    existingDish.Type = updatedDish.Type;

    return Results.NoContent();
});

app.MapDelete("/dishes/{id}", (int id) => {
    Dish? existingDish = dishes.Find(dish => dish.Id == id);
    if(existingDish is not null){
        dishes.Remove(existingDish);
    }

    return Results.NoContent();
});

app.Run();
