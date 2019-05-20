using Food.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.EntityFramework.Repository
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Menu GetMenu(int menuId);
    }
}
