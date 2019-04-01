using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using Food.EntityFramework.Entities.Enums;
using FoodAdmin.Dto.Menu;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodAdmin.Service
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;

        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        //получение списка
        public List<MenuDto> GetMenus()
        {
            List<Menu> menus = _menuRepository.All.ToList();

            return menus.ConvertAll(Convert);
        }

        //получение меню по id
        public MenuDto GetMenu( int menuId )
        {
            if (menuId == 0)
            {
                return CreateMenu();
            }

            Menu menu = _menuRepository.All.FirstOrDefault(item => item.Id == menuId);
            MenuDto menuDto = null;

            if (menu != null)
            {
                return Convert(menu);
            }

            return menuDto;
        }

        //сохранение меню
        public MenuDto SaveMenu( MenuDto menuDto )
        {
            Menu menu = _menuRepository.GetItem(menuDto.MenuId) ?? new Menu();
            menu.CurrentDate = menuDto.CurrentDate;
            menu.StartDate = menuDto.StartDate;
            menu.EndDate = menuDto.EndDate;
            menu.MenuStatus = menuDto.MenuStatus;

            menu = _menuRepository.Save(menu);

            return Convert(menu);
        }

        //удаление
        public void RemoveMenu( int Id )
        {
            _menuRepository.Delete(Id);
        }

        //конвертор
        private MenuDto Convert(Menu menu)
        {
            return new MenuDto
            {
                MenuId = menu.Id,
                CurrentDate = menu.CurrentDate,
                StartDate = menu.StartDate,
                EndDate = menu.EndDate,
                MenuStatus = menu.MenuStatus
                //MenuDate = menu.StartDate,
                //MenuStatus = menu.EndDate > menu.CurrentDate ? MenuStatus.Active : MenuStatus.Closed
            };
        }

        //инициализация нового меню
        public MenuDto CreateMenu()
        {
            return new MenuDto
            {
                MenuId = 0,
                CurrentDate = new DateTime(),
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                MenuStatus = MenuStatus.Closed,
            };
    }
    }
}