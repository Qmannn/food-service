using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.EntityFramework.Repository
{
    public interface IDishRepository: IRepository<Dish>
    {
        List<Dish> GetDishes(List<int> dishIds);
    }
}
