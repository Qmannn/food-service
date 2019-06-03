using System.Collections.Generic;
using FoodAdmin.Dto.Menu;
using FoodAdmin.Dto.Dish;
using Food.EntityFramework.Entities.Enums;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;
using FoodAdmin.Dto.MenuDish;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class MenusApiController : Controller
    {
        private readonly IMenuService _menuService;
        public MenusApiController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //список меню
        [HttpGet("")]
        public List<MenuDto> GetMenus()
        {
            return _menuService.GetMenus();
        }

        [HttpGet("menu")]
        public MenuDto GetMenu(int menuId)
        {
            return _menuService.GetMenu(menuId);
        }

        //список блюд из меню
        [HttpGet("dishes")]
        public List<DishDto> GetMenusDishes(int menuId)
        {
            return _menuService.GetMenuDishes(menuId);

            List<int> SelectedDishesId = new List<int>();

            if (MenuId != 0)
            {
                SelectedDishesId = new List<int> { 1, 2, 3 };
            }

            return new MenuDishDto
            {
                SelectedDishesId = SelectedDishesId,
                Dishes = Dishes
            };
        }

        ////добавление блюда в меню
        //[HttpPost("addmenudish")]
        //public MenuDishDto AddMenuDish([FromBody] MenuDishDto menuDish)
        //{
        //    MenuDishDto menuDishDto = _menuService.SaveMenu(menuDish);

        //    return new MenuDishDto
        //    {
        //        MenuDishId = menuDishDto.MenuDishId,
        //        DishId = menuDishDto.DishId,
        //        MenuId = menuDishDto.MenuId
        //    };
        //}

        //удаление блюда из меню
        [HttpPost("removemenudish")]
        public void RemoveMenuDish(int menuDishId)
        {
            _menuService.RemoveMenuDish(menuDishId);
        }

        [HttpPost("remove")]
        public void RemoveMenu(int Id)
        {
            _menuService.RemoveMenu(Id);
        }

        [HttpPost("save")]
        public void SaveMenu( [FromBody] MenuDto newMenu )
        {
            _menuService.SaveMenu(newMenu);

            
        }
    }
}
