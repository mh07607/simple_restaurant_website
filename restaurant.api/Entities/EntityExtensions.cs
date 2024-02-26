namespace restaurant.api.Entities;
using restaurant.api.Dtos;

public static class EntityExtensions
{
    public static DishDto AsDto(this Dish dish){
        return new DishDto(
            dish.Id,
            dish.Name,
            dish.Type,
            dish.Price,
            dish.ImageUri
        );
    }

    public static Dish AsEntity(this CreateDishDto dishDto){
        return new(){
            Name = dishDto.Name,
            Type = dishDto.Type,
            Price = dishDto.Price,
            ImageUri = dishDto.ImageUri
        };
    }
}