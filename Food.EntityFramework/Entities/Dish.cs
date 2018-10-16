using System;
using System.Collections.Generic;
using System.Text;

namespace Food.EntityFramework.Entities
{
    internal sealed class Dish : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int IdContainer { get; set; }
    }
}
