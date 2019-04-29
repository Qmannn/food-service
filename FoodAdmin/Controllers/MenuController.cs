using System;
using System.Collections.Generic;
using Food.EntityFramework.Entities.Enums;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Dto.Menu;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class MenusController : Controller
    {
        private readonly IMenuService _menuService;

        public MenusController( IMenuService menuService )
        {
            _menuService = menuService;
        }

        //список меню
        [HttpGet("")]
        public List<MenuDto> GetMenus()
        {
            return _menuService.GetMenus();
        }

        //получение меню по id
        [HttpGet("menu")]
        public MenuDto GetMenu( int menuId )
        {
            return _menuService.GetMenu(menuId);
        }

        //сохранение меню
        [HttpPost("save")]
        public MenuDto SaveMenu( [FromBody] MenuDto newMenu )
        {
            MenuDto savedMenuDto = _menuService.SaveMenu(newMenu);

            return new MenuDto
            {
                MenuId = savedMenuDto.MenuId,
                CurrentDate = savedMenuDto.CurrentDate,
                StartDate = savedMenuDto.StartDate,
                EndDate = savedMenuDto.EndDate,
                MenuStatus = savedMenuDto.MenuStatus
            };
        }

        //удаление
        [HttpPost("remove")]
        public void RemoveMenu( int Id )
        {
            _menuService.RemoveMenu(Id);
        }

        [HttpGet("dishes")]
        public MenuDishDto GetDishes( int MenuId )
        {
            List<DishDto> Dishes = new List<DishDto>
            {
                new DishDto
                {
                    DishId = 1,
                    Name = "First Dish 1",
                    Description = "First dish",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 2,
                    Name = "First Dish 2",
                    Description = "First dish",
                    Price = 100,
                    Category = DishCategory.FirstDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 3,
                    Name = "Second Dish 1",
                    Description = "Second dish",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 4,
                    Name = "Second Dish 2",
                    Description = "Second dish",
                    Price = 100,
                    Category = DishCategory.SecondDish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 5,
                    Name = "Salad 1",
                    Description = "salad",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 6,
                    Name = "Salad 1",
                    Description = "salad",
                    Price = 100,
                    Category = DishCategory.Salad,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 7,
                    Name = "Garnish 1",
                    Description = "garnish",
                    Price = 100,
                    Category = DishCategory.Garnish,
                    ContainerId = 1
                },
                new DishDto
                {
                    DishId = 8,
                    Name = "Garnish 2",
                    Description = "garnish",
                    Price = 100,
                    Category = DishCategory.Garnish,
                    ContainerId = 1
                }
            };

            List<int> SelectedDishesId = new List<int>();

            if (MenuId != 0)
            {
                SelectedDishesId = new List<int> { 1, 2, 3 };
            }

            return new MenuDishDto
            {
                SelectedDishesId = SelectedDishesId,
                Dishes = Dishes,
                Menu = new MenuDto()
            };
        }
    }

}
