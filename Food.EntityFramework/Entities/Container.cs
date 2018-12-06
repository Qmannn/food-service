using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    public class Container : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
