using System;
using System.Collections.Generic;
using Food.EntityFramework.Entities;
using FoodService.Dto.Dish;

namespace FoodService.Dto.Menu
{
    public class MenuDto
    {
        public int Id { get; set; }
        public List<DishDto> Dishes{ get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
    }
}
