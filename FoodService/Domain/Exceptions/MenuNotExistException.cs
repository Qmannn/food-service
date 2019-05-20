using System;

namespace FoodService.Domain.Exceptions
{
    public class MenuNotExistException: Exception
    {
        public MenuNotExistException(int menuId) : base($"Меню с id = {menuId} не найдено")
        {
        }
    }
}
