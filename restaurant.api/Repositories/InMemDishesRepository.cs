using restaurant.api.Entities;

namespace restaurant.api.Repositories;

public class InMemDishesRepository : IDishesRepository
{
    private readonly List<Dish> dishes = new(){
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

    public IEnumerable<Dish> GetAll(){
        return dishes;
    }

    public Dish? Get(int id){
        return dishes.Find(dish => dish.Id == id);
    }

    public void Create(Dish dish){
        dish.Id = dishes.Max(dish => dish.Id) + 1;
        dishes.Add(dish);
    }

    public void Update(Dish updatedDish){
        int index = dishes.FindIndex(dish => dish.Id == updatedDish.Id);
        dishes[index] = updatedDish;
    }

    public void Delete(int id){
        var index = dishes.FindIndex(dish => dish.Id == id);
        dishes.RemoveAt(index);
    }
}