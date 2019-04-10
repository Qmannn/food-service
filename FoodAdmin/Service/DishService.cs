using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using Food.EntityFramework.Entities.Enums;
using FoodAdmin.Dto.Dish;

namespace FoodAdmin.Service
{
    public class DishService : IDishService
    {
        private readonly IRepository<Dish> _dishRepository;

        public DishService( IRepository<Dish> dishRepository )
        {
            _dishRepository = dishRepository;
        }
        
        public List<DishDto> GetDishes()
        {
            List<Dish> dishes = _dishRepository.All.ToList();

            return dishes.ConvertAll( ConvertToDto );
        }

        public DishDto GetDish( int dishId )
        {
            if (dishId == 0)
            {
                return CreateDish();
            }

            Dish dish = _dishRepository.All.FirstOrDefault(item => item.Id == dishId);
            DishDto dishDto = null;
            if ( dish != null )
            {
                return ConvertToDto(dish);
            }

            return dishDto;
        }

        public DishDto SaveDish( DishDto dishDto )
        {
            Dish dish = _dishRepository.GetItem(dishDto.DishId) ?? new Dish();
            dish.Name = dishDto.Name;
            dish.Description = dishDto.Description;
            dish.Price = dishDto.Price;
            dish.Category = dishDto.Category;
            dish.ContainerId = dishDto.ContainerId;

            dish = _dishRepository.Save( dish );

            return ConvertToDto( dish );
        }

        private DishDto ConvertToDto( Dish dish )
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

        public DishDto CreateDish()
        {
            return new DishDto
            {
                DishId = 0,
                Name = "Dish",
                Description = "Description",
                Category = DishCategory.FirstDish,
                ContainerId = 1,
                Price = 0
            };
        }
        
        public void RemoveDish( int DishId )
        {
            _dishRepository.Delete(DishId);
        }

        private DishDto Convert( Dish dish )
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