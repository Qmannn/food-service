using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            Order oldOrder = _orderRepository.GetOrderWithDishes(dailyOrder.UserId, dailyOrder.Date) ?? new Order {
                OrderDishes = new List<OrderDish>()
            };

            Order order = ConvertDailyOrderToOrder(oldOrder, dailyOrder);

            order = _orderRepository.Save(order);

            return ConvertOrderToDailyOrder(order);
        }

        private Order ConvertDailyOrderToOrder(Order order, DailyOrder dailyOrder)
        {            
            order.OrderDate = DateTime.Now;
            order.DeliveryDate = dailyOrder.Date;
            order.MenuId = dailyOrder.MenuId;
            order.UserId = dailyOrder.UserId;

            List<OrderDish> oldOrderDishes = new List<OrderDish>(order.OrderDishes);
            decimal totalSum = 0;

            foreach (var orderDish in oldOrderDishes)
            {
                bool dishFound = false;

                foreach (var dailyOrderDish in dailyOrder.Dishes)
                {
                    if (!dishFound && orderDish.DishId == dailyOrderDish.Id)
                    {
                        dishFound = true;
                        break;
                    }
                }

                if (!dishFound)
                {
                    order.OrderDishes.Remove(orderDish);
                }
            }

            foreach (var dailyOrderDish in dailyOrder.Dishes) 
            {
                bool dishFound = false;

                foreach (var orderDish in order.OrderDishes)
                {
                    if (!dishFound && orderDish.DishId == dailyOrderDish.Id)
                    {
                        dishFound = true;
                    }
                }

                if (!dishFound)
                {
                    order.OrderDishes.Add(ConvertDailyOrderDishToOrderDish(dailyOrderDish, dailyOrder.OrderId));
                }
            }

            if (order.OrderDishes != null)
            {
                foreach (var orderDish in order.OrderDishes)
                {
                    totalSum += orderDish.DishPrice;
                }
            }

            order.TotalSum = totalSum;

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
