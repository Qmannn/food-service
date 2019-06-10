using Food.EntityFramework.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Food.EntityFramework.Repository
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        public DishRepository(FoodDbContext foodDbContext) : base(foodDbContext)
        {
        }

        public List<Dish> GetDishes(List<int> dishIds)
        {
            return All.Where(item => dishIds.Contains(item.Id)).ToList();
        }
    }
}
