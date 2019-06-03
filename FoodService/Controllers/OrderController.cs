using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Food.EntityFramework.Entities.Enums;
using System;
using FoodService.Dto.DayMenu;
using FoodService.Dto.Menu;
using FoodService.Dto.Dish;
using FoodService.Dto.Order;
using FoodService.Domain.Services.Builders;
using FoodService.Domain.Entities;
using FoodService.Domain.Services.Finders;
using FoodService.Domain.Services.Savers;
namespace FoodService.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IDailyOrderFinder _dailyOrderFinder;
        private readonly IDailyOrderSaver _dailyOrderSaver;
        private readonly IOrderBuilder _orderBuilder;

        private DailyOrder dailyOrder = new DailyOrder {
            Date = new DateTime(),
            UserId = 1,
            OrderId = 11,
            MenuId = 1,
            Dishes = new List<DailyOrderDish> {
                new DailyOrderDish {
                    Id = 4,
                    Name = "first dish 1",
                    Description = "first dish",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1
                },
                new DailyOrderDish {
                    Id = 5,
                    Name = "first dish 2",
                    Description = "first dish",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1
                },
                new DailyOrderDish {
                    Id = 6,
                    Name = "second dish 1",
                    Description = "second dish",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1
                },
                new DailyOrderDish {
                    Id = 7,
                    Name = "second dish 2",
                    Description = "second dish",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1
                },
                new DailyOrderDish {
                    Id = 8,
                    Name = "salad 1",
                    Description = "salad",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1
                }
            }
        };

        public OrderController(IDailyOrderFinder dailyOrderFinder, IDailyOrderSaver dailyOrderSaver, IOrderBuilder orderBuilder)
        {
            _dailyOrderFinder = dailyOrderFinder;
            _dailyOrderSaver = dailyOrderSaver;
            _orderBuilder = orderBuilder;
        }

        [HttpGet("saveDailyOrder")]
        public DailyOrder SaveDailyOrder()
        {
            return _dailyOrderSaver.SaveDailyOrder(dailyOrder);
        }
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
                    Name = "Борщ",
                    Description = "First description",
                    Price = 170,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1,
                },
                new DishDto
                {
                    Id = 8,
                    Name = "Салат",
                    Description = "Second description",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 2,
                },
            };
            dayMenu.Menu = new MenuDto()
            {
                Id = 1,
                CurrentDate = menuDate
            };
            return dayMenu;
        }

        [HttpPost("make-order")]
        public OrderDto MakeOrder([FromBody] OrderDto order)
        {
            _orderBuilder.BuildDailyOrder(order);
            return order;
        }
    }
}
