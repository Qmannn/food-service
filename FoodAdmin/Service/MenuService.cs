using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.Menu;

namespace FoodAdmin.Service
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;

        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<MenuDto> GetMenus()
        {
            List<Menu> menus = _menuRepository.All.ToList();

            return menus.ConvertAll(Convert);
        }

        private MenuDto Convert(Menu menu)
        {
            return new MenuDto
            {
                MenuId = menu.Id,
                MenuDate = menu.StartDate,
                MenuStatus = menu.EndDate > menu.CurrentDate ? MenuStatus.Active : MenuStatus.Closed
            };
        }
    }
}