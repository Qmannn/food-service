using FoodService.Dto.Dish;
using System;

namespace FoodService.Domain.Exceptions
{
    public class DishNotExistException: Exception
    {
        public DishNotExistException(DishDto dish) : base($"Блюдо {dish.Id} {dish.Name} не найдено")
        {
        }
    }
}
