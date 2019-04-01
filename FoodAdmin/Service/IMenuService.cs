using System.Collections.Generic;
using FoodAdmin.Dto.Menu;

namespace FoodAdmin.Service
{
    public interface IMenuService
    {
        List<MenuDto> GetMenus(); //получение списка
        MenuDto GetMenu( int menuId ); //получение меню по id
        MenuDto SaveMenu( MenuDto menuDto ); //сохранение меню
        void RemoveMenu( int menuId ); //удаление
    }
}