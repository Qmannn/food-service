using System.Collections.Generic;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;
using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController( IDishService dishService )
        {
            _dishService = dishService;
        }

        [HttpGet("dishes")]
        public List<DishDto> GetDishes()
        {
            var storedDishes = _dishService.GetDishes();

            if (storedDishes.Count > 0)
            {
                return storedDishes;
            }

            return new List<DishDto>
            {
                 new DishDto
                {
                    DishId = 1,
                    Name = "Борщ",
                    Description = "First description",
                    Price = 170,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    DishId = 2,
                    Name = "Салат",
                    Description = "Second description",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 2,
                },
            };
        }

        [HttpGet("dish")]
        public DishDto GetDish( int dishId )
        {
            return _dishService.GetDish(dishId);
        }

        [HttpPost("dish")]
        public SavedDishInfo SaveDish( [FromBody] DishDto dish )
        {
            DishDto savedDishDto = _dishService.SaveDish(dish);

            return new SavedDishInfo
            {
                SavedDishId = savedDishDto.DishId,
                SavedName = savedDishDto.Name,
                SavedDescription = savedDishDto.Description,
                SavedPrice = savedDishDto.Price,
                SavedCategory = savedDishDto.Category,
                SavedContainerId = savedDishDto.ContainerId,
            };
        }
    }
  
}
