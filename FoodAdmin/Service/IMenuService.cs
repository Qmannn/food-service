using System.Collections.Generic;
using FoodAdmin.Dto.Menu;

namespace FoodAdmin.Service
{
    public interface IMenuService
    {
        List<MenuDto> GetMenus();
    }
}