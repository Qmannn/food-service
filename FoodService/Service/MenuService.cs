using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodService.Dto.Menu;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Service
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;

        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public MenuDto GetMenu(int id)
        {
            Menu menu = _menuRepository.GetItem(id);

            return Convert(menu);
        }

        private MenuDto Convert(Menu menu)
        {
            return new MenuDto
            {
                Id = menu.Id,
                CurrentDate = menu.CurrentDate,
                StartDate = menu.StartDate,
                EndDate = menu.EndDate,
            };
        }
    }
}