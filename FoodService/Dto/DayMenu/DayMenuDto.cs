using FoodService.Dto.Dish;
using FoodService.Dto.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Dto.DayMenu
{
    public class DayMenuDto
    {
        public List<DishDto> MenuDishes { get; set; }
        public MenuDto Menu { get; set; }
    }
}
