using Food.EntityFramework.Entities.Enums;

namespace FoodService.Domain.Entities
{
    public class DailyOrderDish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DishCategory Category { get; set; }
        public int ContainerId { get; set; }
    }
}
