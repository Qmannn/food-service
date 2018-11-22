using System;
using System.Collections.Generic;
using FoodAdmin.Dto.DishList;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class DishesApiController : Controller
    {
        [HttpGet("dishes")]
        public List<DishDto> GetDishes()
        {
            return new List<DishDto>
            {
                new DishDto
                {
                    DishName = "Блинчики с клубничной начинкой",
                    DishPrice = 55,
                    DishType = Dto.DishList.Enum.DishType.SecondDish,
                    DishWeight = 140
                },
                new DishDto
                {
                    DishName = "Буженина из баранины с соусом",
                    DishPrice = 180,
                    DishType = Dto.DishList.Enum.DishType.Garnish,
                    DishWeight = 100
                },
                new DishDto
                {
                    DishName = "Макароны отварные с овощами",
                    DishPrice = 16,
                    DishType = Dto.DishList.Enum.DishType.Garnish ,
                    DishWeight = 200
                },
                new DishDto
                {
                    DishName = "Рассольник Ленинградский",
                    DishPrice = 52,
                    DishType = Dto.DishList.Enum.DishType.Soup,
                    DishWeight = 250
                },
                new DishDto
                {
                    DishName = "Салат Кировский",
                    DishPrice = 68,
                    DishType = Dto.DishList.Enum.DishType.Salad,
                    DishWeight = 120
                },
            };
        }
    }
}
