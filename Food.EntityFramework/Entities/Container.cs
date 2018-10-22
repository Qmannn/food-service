using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    internal class Container : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Container()
        {
            Dishes = new List<Dish>();
        }
        public virtual List<Dish> Dishes { get; set; }
    }
}
