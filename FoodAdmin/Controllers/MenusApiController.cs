using System.Collections.Generic;
using FoodAdmin.Dto.Menu;
using FoodAdmin.Dto.Dish;
using Food.EntityFramework.Entities.Enums;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class MenusApiController : Controller
    {
        private readonly IMenuService _menuService;
        public MenusApiController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("")]
        public List<MenuDto> GetMenus()
        {
            return _menuService.GetMenus();
        }

        [HttpGet("dishes")]
        public List<DishDto> GetDishes()
        {
            return new List<DishDto>
            {
                new DishDto
                {
                    DishId = 1,
                    Name = "First Dish 1",
                    Description = "First dish",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 2,
                    Name = "First Dish 2",
                    Description = "First dish",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 3,
                    Name = "Second Dish 1",
                    Description = "Second dish",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 4,
                    Name = "Second Dish 2",
                    Description = "Second dish",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 5,
                    Name = "Salad 1",
                    Description = "salad",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 6,
                    Name = "Salad 1",
                    Description = "salad",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 7,
                    Name = "Garnish 1",
                    Description = "garnish",
                    Price = 100,
                    Category = DishCategory.Garnish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 8,
                    Name = "Garnish 2",
                    Description = "garnish",
                    Price = 100,
                    Category = DishCategory.Garnish,
                    ContainerId = 1
                }
            };
        }
    }
}
