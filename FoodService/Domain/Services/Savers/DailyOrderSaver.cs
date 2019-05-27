using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FoodService.Domain.Services.Savers
{
    public class DailyOrderSaver : IDailyOrderSaver
    {
        private readonly IOrderRepository _orderRepository;

        public DailyOrderSaver(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DailyOrder SaveDailyOrder(DailyOrder dailyOrder)
        {
            Order order = ConvertDailyOrderToOrder(dailyOrder);
            Order oldOrder = _orderRepository.GetOrder(dailyOrder.UserId, dailyOrder.Date);
            if (oldOrder != null)
            {
                order.Id = oldOrder.Id;
            }

            /*
             * The instance of entity type 'Order' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.
            */

            order = _orderRepository.Save(order);

            return ConvertOrderToDailyOrder(order);
        }

        private Order ConvertDailyOrderToOrder(DailyOrder dailyOrder)
        {
            Order order = new Order();
            
            order.OrderDate = DateTime.Now;
            order.DeliveryDate = dailyOrder.Date;
            order.MenuId = dailyOrder.MenuId;
            order.UserId = dailyOrder.UserId;
            order.OrderDishes = new List<OrderDish>();

            decimal TotalSum = 0; 

            if (dailyOrder.Dishes != null)
            {
                foreach (var dailyOrderDish in dailyOrder.Dishes)
                {
                    TotalSum += dailyOrderDish.Price;
                    order.OrderDishes.Add(ConvertDailyOrderDishToOrderDish(dailyOrderDish, dailyOrder.OrderId));
                }
            }

            order.TotalSum = TotalSum;

            return order;
        }

        private OrderDish ConvertDailyOrderDishToOrderDish(DailyOrderDish dailyOrderDish, int orderId)
        {
            return new OrderDish
            {
                OrderId = orderId,
                DishName = dailyOrderDish.Name,
                DishDescription = dailyOrderDish.Description,
                DishPrice = dailyOrderDish.Price,
                DishCategory = dailyOrderDish.Category,
                DishContainerId = dailyOrderDish.ContainerId,
                DishId = dailyOrderDish.Id
            };
        }

        private DailyOrder ConvertOrderToDailyOrder(Order order)
        {
            DailyOrder dailyOrder = new DailyOrder(order);

            dailyOrder.Dishes = new List<DailyOrderDish>();

            if (order.OrderDishes != null)
            {
                foreach (var orderDish in order.OrderDishes)
                {
                    dailyOrder.Dishes.Add(new DailyOrderDish(orderDish));
                }
            }

            return dailyOrder;
        }
    }
}
