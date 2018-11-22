using FoodAdmin.Dto.DishList.Enum;

namespace FoodAdmin.Dto.DishList
{
    public class DishDto
    {
        public string DishName { get; set; }
        public int DishPrice { get; set; }
        public int DishWeight { get; set; }
        public DishType DishType { get; set; }
    }
}
