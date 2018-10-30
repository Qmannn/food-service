using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    internal class Container : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
