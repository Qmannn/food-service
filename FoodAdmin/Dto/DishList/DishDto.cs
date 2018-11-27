using FoodAdmin.Dto.DishList.Enum;

namespace FoodAdmin.Dto.DishDto
{
    public class DishDto
    {
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public int DishWeight { get; set; }
        public DishType DishType { get; set; }
    }
}
