using System;
using System.Collections.Generic;
using FoodAdmin.Dto.FoodList;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class FoodListController : Controller
    {
        [HttpGet("foodlist")]
        public List<FoodListDto> GetSamples()
        {
            return new List<FoodListDto>
            {
                new FoodListDto
                {
                    FoodName = "Блинчики с клубничной начинкой",
                    PriceFood = 55,
                    TypeFood = "Второе блюдо",
                    WeightFood = 140
                },
                new FoodListDto
                {
                    FoodName = "Буженина из баранины с соусом",
                    PriceFood = 180,
                    TypeFood = "Второе блюдо",
                    WeightFood = 100
                },
                new FoodListDto
                {
                    FoodName = "Макароны отварные с овощами",
                    PriceFood = 16,
                    TypeFood = "Гарнир",
                    WeightFood = 200
                },
                new FoodListDto
                {
                    FoodName = "Рассольник Ленинградский",
                    PriceFood = 52,
                    TypeFood = "Суп",
                    WeightFood = 250
                },
                new FoodListDto
                {
                    FoodName = "Салат Кировский",
                    PriceFood = 68,
                    TypeFood = "Салат",
                    WeightFood = 120
                },
            };
        }
    }
}
