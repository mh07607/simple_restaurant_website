namespace restaurant.api.Entities;

public class Dish
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public decimal Price { get; set; }
    public required string ImageUri { get; set; }
}