using restaurant.api.Entities;

namespace restaurant.api.Repositories;

public interface IDishesRepository{
    void Create(Dish dish);

    void Delete(int id);

    Dish? Get(int id);

    IEnumerable<Dish> GetAll();

    void Update(Dish updatedDish);
}
