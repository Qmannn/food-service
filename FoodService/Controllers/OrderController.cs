using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Food.EntityFramework.Entities.Enums;
using System;
using FoodService.Dto.DayMenu;
using FoodService.Dto.Menu;
using FoodService.Dto.Dish;
using FoodService.Dto.Order;
using FoodService.Domain.Entities;
using FoodService.Domain.Services.Finders;
using FoodService.Domain.Services.Savers;
using FoodService.Domain.Services.Builders;

namespace FoodService.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IDailyOrderFinder _dailyOrderFinder;
        private readonly IDailyOrderSaver _dailyOrderSaver;
        private readonly IOrderBuilder _orderBuilder;
        private readonly IDailyMenuFinder _dailyMenuFinder;

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

        public OrderController(IDailyOrderFinder dailyOrderFinder, IDailyOrderSaver dailyOrderSaver, IOrderBuilder orderBuilder, IDailyMenuFinder dailyMenuFinder)
        {
            _dailyOrderFinder = dailyOrderFinder;
            _dailyOrderSaver = dailyOrderSaver;
            _orderBuilder = orderBuilder;
            _dailyMenuFinder = dailyMenuFinder;
        }

        [HttpGet("saveDailyOrder")]
        public DailyOrder SaveDailyOrder()
        {
            return _dailyOrderSaver.SaveDailyOrder(dailyOrder);
        }

        [HttpGet("dailyOrder")]
        public DailyOrder GetOrder()
        {
            DateTime date = new DateTime(2019, 05, 05);
            return _dailyOrderFinder.GetDailyOrder(1, date);
        }

        [HttpGet("menu-on-day")]
        public DayMenuDto GetMenuOnDay(DateTime menuDate)
        {
            return _dailyMenuFinder.GetMenuFromDate(menuDate);
        }

        [HttpPost("make-order")]
        public OrderDto MakeOrder([FromBody] OrderDto order)
        {
            var dailyOrder = _orderBuilder.BuildDailyOrder(order);
            _dailyOrderSaver.SaveDailyOrder(dailyOrder);
            return order;
        }
    }
}
