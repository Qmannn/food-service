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
        public virtual ICollection<MenuDish> MenuDishes { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}
