using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Dto.DishDto
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DishCategory Category { get; set; }
        public int ContainerId { get; set; }
    }
}
