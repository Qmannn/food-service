using System;
using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    internal class Menu : IEntity
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }

        public Menu()
        {
            MenuDishes = new List<MenuDish>();
            Orders = new List<Order>();
        }
        public virtual List<MenuDish> MenuDishes { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
