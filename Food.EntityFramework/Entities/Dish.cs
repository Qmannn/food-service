using System.Collections.Generic;
using Food.EntityFramework.Entities.Enums;

namespace Food.EntityFramework.Entities
{
    internal class Dish : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DishCategory Category { get; set; }

        public int ContainerId { get; set; }
        public virtual Container Container { get; set; }

        public Dish()
        {
            MenuDishes = new List<MenuDish>();
            OrderDishes = new List<OrderDish>();
        }
        public virtual List<MenuDish> MenuDishes { get; set; }
        public virtual List<OrderDish> OrderDishes { get; set; }
    }
}
