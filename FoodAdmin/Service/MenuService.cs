using System;
using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodAdmin.Dto.Dish;
using FoodAdmin.Dto.Menu;

namespace FoodAdmin.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<MenuDish> _menuDishRepository;

        public MenuService(IMenuRepository menuRepository, IRepository<Dish> dishRepository, IRepository<MenuDish> menuDishRepository)
        {
            _menuRepository = menuRepository;
            _dishRepository = dishRepository;
            _menuDishRepository = menuDishRepository;
        }

        public MenuDto GetMenu(int menuId)
        {
            if (menuId == 0)
            {
                return CreateMenu();
            }

            Menu menu = _menuRepository.GetByMenuId(menuId);
            MenuDto menuDto = null;

            if (menu != null)
            {
                return Convert(menu);
            }

            return menuDto;
        }

        public MenuDto CreateMenu()
        {
            return new MenuDto
            {
                MenuId = 0,
                CurrentDate = new DateTime(),
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                MenuStatus = MenuStatus.Closed
            };
        }

        public List<DishDto> GetMenuDishes(int menuId)
        {
            List<DishDto> menuDishes = new List<DishDto>();
            Menu menu = _menuRepository.GetByMenuId(menuId);
            if(menu == null)
            {
                return menuDishes;
            }

            List<Dish> allDishes = _dishRepository.All.ToList();

            foreach (MenuDish menuDish in menu.MenuDishes)
            {
                Dish dish = allDishes.FindLast(item => item.Id == menuDish.DishId);
                menuDishes.Add(ConvertToDto(dish));
            }

            return menuDishes;
        }

        public void SaveMenu( MenuDto menuDto )
        {
            Menu menu = _menuRepository.GetByMenuId(menuDto.MenuId) ?? new Menu
            {
                MenuDishes = new List<MenuDish>()
            };
            menu.CurrentDate = menuDto.CurrentDate;
            menu.StartDate = menuDto.StartDate;
            menu.EndDate = menuDto.EndDate;
            menu.MenuStatus = menuDto.MenuStatus;

            IEnumerable<int> dishesIds = 
                menu.MenuDishes != null ? menu.MenuDishes.Select(item => item.DishId) : new List<int>();
            List<int> toAdd = menuDto.Dishes.Except(dishesIds).ToList();

            List<MenuDish> toRemove = new List<MenuDish>();
            foreach(MenuDish menuDish in menu.MenuDishes)
            {
                if (!menuDto.Dishes.Contains(menuDish.DishId))
                {
                    toRemove.Add(menuDish);
                }
            }

            foreach (MenuDish dish in toRemove)
            {
                menu.MenuDishes.Remove(dish);
            }

            foreach (var dishId in menuDto.Dishes)
            {
                if (!menu.MenuDishes.Any(item => item.DishId == dishId))
                {
                    menu.MenuDishes.Add(new MenuDish
                    {
                        MenuId = menu.Id,
                        DishId = dishId
                    });
                }
            }

            menu = _menuRepository.Save(menu);
        }

        private DishDto ConvertToDto(Dish dish)
        {
            return new DishDto
            {
                DishId = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Category = dish.Category,
                ContainerId = dish.ContainerId
            };
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
                CurrentDate = menu.CurrentDate,
                StartDate = menu.StartDate,
                EndDate = menu.EndDate,
                MenuStatus = menu.EndDate > menu.CurrentDate ? MenuStatus.Active : MenuStatus.Closed,
                Dishes = menu.MenuDishes != null ? menu.MenuDishes.Select(item => item.DishId).ToList() : null
            };
        }

        public void RemoveMenuDish(int menuDishId)
        {
            _menuDishRepository.Delete(menuDishId);
        }

        public void RemoveMenu(int Id)
        {
            _menuRepository.Delete(Id);
        }
    }
}