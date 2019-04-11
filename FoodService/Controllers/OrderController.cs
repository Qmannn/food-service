using System.Collections.Generic;
using FoodService.Service;
using Microsoft.AspNetCore.Mvc;
using Food.EntityFramework.Entities.Enums;
using System;
using FoodService.Dto.DayMenu;
using FoodService.Dto.Menu;
using FoodService.Dto.Dish;

namespace FoodService.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        [HttpGet("menu-on-day")]
        public DayMenuDto GetMenuOnDay(DateTime menuDate)
        {
            DayMenuDto dayMenu = new DayMenuDto();
            dayMenu.MenuDishes = new List<DishDto>
            {
                new DishDto
                {
                    Id = 0,
                    Name = "First dish 1",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 1,
                    Name = "Second dish 1",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 2,
                    Name = "Garnish 1",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.Garnish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 3,
                    Name = "Salad 1",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 4,
                    Name = "First dish 2",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 5,
                    Name = "Salad 2",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 6,
                    Name = "Garnish 2",
                    Description = "dish description",
                    Price = 100,
                    Category = DishCategory.Garnish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 7,
                    Name = "����",
                    Description = "First description",
                    Price = 170,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 8,
                    Name = "�����",
                    Description = "Second description",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 2,
                },
            };
            dayMenu.Menu = new MenuDto()
            {
                CurrentDate = menuDate
            };
            return dayMenu;
        }
    }
}
