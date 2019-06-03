using Food.EntityFramework.Entities;
using Food.EntityFramework.Repository;
using FoodService.Dto.DayMenu;
using FoodService.Dto.Dish;
using FoodService.Dto.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodService.Domain.Services.Finders
{
    public class DailyMenuFinder : IDailyMenuFinder
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IDishRepository _dishRepository;

        public DailyMenuFinder(IMenuRepository menuRepository, IDishRepository dishRepository)
        {
            _menuRepository = menuRepository;
            _dishRepository = dishRepository;
        }

        public DayMenuDto GetMenuFromDate(DateTime menuDate)
        {
            Menu menuDB = _menuRepository.GetMenu(menuDate);
            DayMenuDto dayMenuDto = new DayMenuDto();
            dayMenuDto.Menu = new MenuDto();
            if (menuDB != null)
            {
                List<int> dishIds = menuDB.MenuDishes.Select(item => item.DishId).ToList();
                List<Dish> dishes = _dishRepository.GetDishes(dishIds);
                dayMenuDto.Menu.Id = menuDB.Id;
                dayMenuDto.Menu.StartDate = menuDB.StartDate;
                dayMenuDto.Menu.EndDate = menuDB.EndDate;
                dayMenuDto.Menu.CurrentDate = menuDB.CurrentDate;
                dayMenuDto.MenuDishes = dishes.ConvertAll(Convert);
            }
            else
            {
                dayMenuDto.MenuDishes = new List<DishDto>();
            }
            
            return dayMenuDto;
        }

        private DishDto Convert(Dish dish)
        {
            return new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Category = dish.Category,
                ContainerId = dish.ContainerId
            };
        }
    }
}
