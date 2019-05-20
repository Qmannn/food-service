using System.Collections.Generic;
using FoodService.Dto.Menu;

namespace FoodService.Service
{
    public interface IMenuService
    {
        MenuDto GetMenu(int id);
    }
}