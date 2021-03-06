﻿using System;
using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    public class Menu : IEntity
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
        public MenuStatus MenuStatus { get; set; }

        public virtual ICollection<MenuDish> MenuDishes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
