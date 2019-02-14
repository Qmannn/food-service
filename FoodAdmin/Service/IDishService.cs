using System.Collections.Generic;
using FoodAdmin.Dto.Dish;

namespace FoodAdmin.Service
{
    public interface IDishService
    {
        DishDto GetDish( int dishId );
        DishDto SaveDish( DishDto dishDto );
        List<DishDto> GetDishes();
        void RemoveDish( int dishId );
    }
}