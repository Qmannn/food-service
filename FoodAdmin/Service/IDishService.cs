using System.Collections.Generic;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Dto.Container;

namespace FoodAdmin.Service
{
    public interface IDishService
    {
        DishDto GetDish( int dishId );
        List<ContainerDto> GetContainers();
        DishDto SaveDish( DishDto dishDto );
    }
}