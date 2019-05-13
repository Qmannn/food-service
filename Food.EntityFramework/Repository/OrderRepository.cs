using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Food.EntityFramework.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodDbContext foodDbContext): base(foodDbContext)
        {

        }

        public Order GetOrderWithDishes(int userId, DateTime deliveryDate)
        {
            return All.Include(item => item.OrderDishes).FirstOrDefault(item => item.UserId == userId && item.DeliveryDate == deliveryDate);
        }
    }
}
