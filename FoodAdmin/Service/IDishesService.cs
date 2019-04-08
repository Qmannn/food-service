using FoodAdmin.Dto;
using FoodAdmin.Dto.Dish;
using System.Collections.Generic;

namespace FoodAdmin.Service
{
    public interface IDishesService
    {
        List<DishDto> GetDishes();
        void RemoveDish(int Id);
    }
}
