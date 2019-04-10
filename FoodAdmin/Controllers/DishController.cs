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

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet("dishes")]
        public List<DishDto> GetDishes()
        {
            var storedDishes = _dishService.GetDishes();

            return _dishService.GetDishes(); ;
        }

        [HttpGet("dish")]
        public DishDto GetDish(int dishId)
        {
            return _dishService.GetDish(dishId);
        }

        [HttpPost("remove")]
        public void RemoveDish( int DishId )
        {
            _dishService.RemoveDish(DishId);
        }

        [HttpPost("save")]
        public DishDto SaveDish([FromBody] DishDto dish)
        {
            DishDto dishDto = _dishService.SaveDish(dish);

            return new DishDto
            {
                DishId = dishDto.DishId,
                Name = dishDto.Name,
                Description = dishDto.Description,
                Price = dishDto.Price,
                Category = dishDto.Category,
                ContainerId = dishDto.ContainerId,
            };
        }
    }

}
