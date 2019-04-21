using FoodService.Dto.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Dto.Order
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public List<DishDto> OrderDishes { get; set; }
    }
}
