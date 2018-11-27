using System.Collections.Generic;
using FoodAdmin.Dto.Dish;
using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Service
{
    public interface IDishService
    {
        DishDto GetDish( int dishId );
        List<DishDto> GetDishes();
        DishDto SaveDish( DishDto dishDto );
    }
}