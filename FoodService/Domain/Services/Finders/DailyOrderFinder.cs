using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodService.Domain.Entities;
using System;

namespace FoodService.Domain.Services.Finders
{
    public class DailyOrderFinder
    {
        private readonly IOrderRepository _orderRepository;

        public DailyOrderFinder(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DailyOrder GetDailyOrder(int userId, DateTime date)
        {
            Order order = _orderRepository.GetOrder(userId, date);
            if (order == null)
            {
                return null;
            }


            // TODO: get order dishes
            // TODO convert orderDish to DailyOrderDish


            return new DailyOrder(order);
        }
    }
}
