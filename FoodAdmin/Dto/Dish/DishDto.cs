using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Dto.Dish
{
    public class DishDto
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        /*public DishCategory Category { get; set; }
        public int ContainerId { get; set; }*/
    }
}