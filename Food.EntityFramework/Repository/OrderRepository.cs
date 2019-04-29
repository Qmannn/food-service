using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Food.EntityFramework.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodDbContext foodDbContext): base(foodDbContext)
        {

        }

        public Order GetOrder(int userId, DateTime deliveryDate)
        {
            return All.FirstOrDefault(item => item.UserId == userId && item.DeliveryDate == deliveryDate);
        }
    }
}
