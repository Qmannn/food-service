using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Dto.DishDto;

namespace FoodAdmin.Service
{
    public interface IDishesService
    {
        List<DishDto> GetDishes();
        void RemoveDish(int Id);
    }
}
