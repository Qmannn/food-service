using Food.EntityFramework.Entities;
using FoodService.Domain.Entities;
using FoodService.Domain.Exceptions;
using FoodService.Dto.Dish;
using FoodService.Dto.Order;
using System.Collections.Generic;
using System.Linq;

namespace FoodService.Domain.Services.Converters
{
    public class DailyOrderConverter: IDailyOrderConverter
    {
        public DailyOrder ConvertDailyOrder(OrderDto order, User user, Menu menu)
        {
            DailyOrder convertedOrder = new DailyOrder();
            convertedOrder.UserId = user.Id;
            convertedOrder.MenuId = menu.Id;
            convertedOrder.Date = menu.CurrentDate;
            convertedOrder.Dishes = new List<DailyOrderDish>();
            HashSet<int> existingDishIds = new HashSet<int>(menu.MenuDishes.Select(item => item.DishId));
            foreach (DishDto dish in order.OrderDishes)
            {
                if (existingDishIds.Contains(dish.Id))
                {
                    DailyOrderDish dailyDish = ConvertOrderDish(dish);
                    convertedOrder.Dishes.Add(dailyDish);
                }
                else
                {
                    throw new DishNotExistException(dish);
                }
            }
            return convertedOrder;
        }

        private DailyOrderDish ConvertOrderDish(DishDto dish)
        {
            return new DailyOrderDish()
            {
                Id = dish.Id,
                Name = dish.Name,
                Price = dish.Price,
                Description = dish.Description,
                Category = dish.Category,
                ContainerId = dish.ContainerId
            };
        }
    }
}
