using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;

namespace FoodService.Domain.Entities
{
    public class DailyOrder
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public List<DailyOrderDish> Dishes { get; set; }

        public DailyOrder()
        {

        }

        public DailyOrder( Order order )
        {
            Date = order.DeliveryDate;
            UserId = order.UserId;
            OrderId = order.Id;
            MenuId = order.MenuId;
        }
    }
}
