using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Food.EntityFramework.Repository
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(FoodDbContext foodDbContext) : base(foodDbContext)
        {
        }

        public Menu GetMenu(int menuId)
        {
            return All.Where(item => item.Id == menuId).Include(item => item.MenuDishes).FirstOrDefault();
        }

        public Menu GetMenu(DateTime menuDate)
        {
            return All.Where(item => item.CurrentDate == menuDate).Include(item => item.MenuDishes).FirstOrDefault();
        }

        public Menu GetByMenuId( int menuId )
        {
            return All.Where(item => item.Id == menuId)
                .Include(item => item.MenuDishes)
                .FirstOrDefault();
        }
    }
}
