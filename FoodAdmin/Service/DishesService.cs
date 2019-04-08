using System;
using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework.Entities;
using Food.EntityFramework;
using FoodAdmin.Dto;
using FoodAdmin.Dto.Dish;

namespace FoodAdmin.Service
{
    public class DishesService : IDishesService
    {
        private readonly IRepository<Dish> _dishRepository;

        public DishesService(IRepository<Dish> dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public List<DishDto> GetDishes()
        {
            List<Dish> dishes = _dishRepository.All.ToList();
            return dishes.ConvertAll(Convert);
        }

        public void RemoveDish(int Id)
        {
            _dishRepository.Delete(Id);
        }

        private DishDto Convert(Dish dish)
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
    }
}
