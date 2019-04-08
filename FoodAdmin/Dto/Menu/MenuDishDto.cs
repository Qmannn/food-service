using System.Collections.Generic;

namespace FoodAdmin.Dto.Menu
{
    public class MenuDishDto
    {
        public List<int> SelectedDishesId { get; set; }
        public List<Dish.DishDto> Dishes { get; set; }
    }
}
