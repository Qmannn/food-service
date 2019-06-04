using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;

namespace FoodAdmin.Dto.Menu
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
        public MenuStatus MenuStatus { get; set; }
        public List<int> Dishes { get; set; }
    }
}