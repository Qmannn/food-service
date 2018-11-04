using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core
{
    public interface IDish
    {
        public int DishId { get; }
        public int DishCost { get; }
        public string DishName { get; }
        public string DishDescription { get; }
        public string DishCategory { get; }
        public IContainer Container { get; }//id контейнерa
    }
}