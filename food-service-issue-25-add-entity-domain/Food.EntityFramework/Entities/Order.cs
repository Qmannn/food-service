using System;
using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    internal class Order : IEntity
    {
        public int Id { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int MenuId { get; set; }
        public int UserId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}
