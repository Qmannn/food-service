using System;
using Food.EntityFramework.Entities;

namespace FoodService.Dto.Menu
{
    public class MenuDto
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
    }
}
