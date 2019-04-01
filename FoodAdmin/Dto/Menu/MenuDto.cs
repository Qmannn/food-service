using System;
using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Dto.Menu
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
        public MenuStatus MenuStatus { get; set; }
    }
}