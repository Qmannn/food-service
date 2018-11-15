using System;
using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
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

            return dishes.ConvertAll( Convert );
        }

        public DishDto GetDish( int dishId )
        {
            Dish dish = _dishRepository.All.FirstOrDefault( item => item.Id == dishId );
            DishDto dishDto = null;
            if ( dish != null )
            {
                dishDto = Convert( dish );
            }

            return dishDto;
        }

        public DishDto SaveDish( DishDto dishDto )
        {
            Dish dish = _dishRepository.GetItem(dishDto.DishId);
                
            dish.Name = dishDto.Name;
            dish.Description = dishDto.Description;
            dish.Price = dishDto.Price;

            dish = _dishRepository.Save( dish );

            return Convert( dish );
        }

        private DishDto Convert( Dish dish )
        {
            return new DishDto
            {
                DishId = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price
            };
        }
    }
}