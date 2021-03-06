﻿using Food.EntityFramework.Entities.Enums;

namespace Food.EntityFramework.Entities
{
    public class OrderDish : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public decimal DishPrice { get; set; }
        public DishCategory DishCategory { get; set; }
        public int DishContainerId { get; set; }
        public int DishId { get; set; }

        public virtual Order Order { get; set; }
    }
}