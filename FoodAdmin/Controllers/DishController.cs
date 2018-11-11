using System.Collections.Generic;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Dto.Container;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController( IDishService dishService )
        {
            _dishService = dishService;
        }

        [HttpGet("dish")]
        public List<ContainerDto> GetContainers()
        {
            var storedContainers = _dishService.GetContainers();

            if (storedContainers.Count > 0)
            {
                return storedContainers;
            }

            return new List<ContainerDto>
            {
                new ContainerDto
                {
                    Id = 1,
                    Name = "first",
                    Price = 12
                },
                new ContainerDto
                {
                    Id = 2,
                    Name = "second",
                    Price = 13
                },
                new ContainerDto
                {
                    Id = 3,
                    Name = "third",
                    Price = 14
                },
            };
        }

        [HttpGet("dish")]
        public DishDto GetDish(int dishId)
        {
            return _dishService.GetDish( dishId );
        }
    }
}
