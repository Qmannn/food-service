using FoodAdmin.Dto.Dish;
using System.Collections.Generic;

namespace FoodAdmin.Dto.Menu
{
    public class MenuDishDto
    {
        public List<int> SelectedDishesId { get; set; }
        public List<DishDto> Dishes { get; set; }
        public MenuDto Menu { get; set; }
    }
}
