using System.Collections.Generic;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

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
                    DishId = 10,
                    Name = "Test1",
                    Description = "First description",
                    Price = 17
                },
                new DishDto
                {
                    DishId = 15,
                    Name = "Test2",
                    Description = "Description",
                    Price = 10
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
            };
        }
    }
  
}
