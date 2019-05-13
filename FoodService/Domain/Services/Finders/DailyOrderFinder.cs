using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FoodService.Domain.Services.Finders
{
    public class DailyOrderFinder : IDailyOrderFinder
    {
        private readonly IOrderRepository _orderRepository;

        public DailyOrderFinder(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DailyOrder GetDailyOrder(int userId, DateTime date)
        {
            Order order = _orderRepository.GetOrderWithDishes(userId, date);
            if (order == null)
            {
                return null;
            }
            DailyOrder dailyOrder = new DailyOrder(order);
            dailyOrder.Dishes = new List<DailyOrderDish>();
            foreach (var orderDish in order.OrderDishes)
            {
                dailyOrder.Dishes.Add(new DailyOrderDish(orderDish));
            }

            return dailyOrder;
        }
    }
}
