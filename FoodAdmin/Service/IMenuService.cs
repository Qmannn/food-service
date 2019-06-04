using System.Collections.Generic;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Dto.Menu;
using FoodAdmin.Dto.MenuDish;

namespace FoodAdmin.Service
{
    public interface IMenuService
    {
        List<MenuDto> GetMenus();
        List<DishDto> GetMenuDishes(int menuId);
        void SaveMenu(MenuDto menuDto);
        void RemoveMenuDish(int menuDishId);
        MenuDto GetMenu(int menuId);
        void RemoveMenu(int menuId); 
    }
}