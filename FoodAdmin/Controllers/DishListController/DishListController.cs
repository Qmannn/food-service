using System.Collections.Generic;
using FoodAdmin.Service;
using Food.EntityFramework.Entities.Enums;
using FoodAdmin.Dto.DishDto;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class DishesApiController : Controller
    {
        private readonly IDishesService _dishesService;
        public DishesApiController(IDishesService dishesService)
        {
            _dishesService = dishesService;
        }

        [HttpGet("dishes")]
        public List<DishDto> GetDishes()
        {
            var storedDishes = _dishesService.GetDishes();

            return storedDishes;
        }

        [HttpPost("remove")]
        public void RemoveDish(int Id)
        {
            _dishesService.RemoveDish(Id);
        }
    }
}
