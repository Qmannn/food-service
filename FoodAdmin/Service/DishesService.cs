using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Dto.DishDto;
using Food.EntityFramework.Entities;
using Food.EntityFramework;

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
