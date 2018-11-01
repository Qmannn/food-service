using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAdmin.Dto.PageName;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class MenusApiController : Controller
    {
        [HttpGet("menus")]
        public List<MenuDto> GetMenus()
        {
            return new List<MenuDto>
            {
                new MenuDto
                {
                    MenuId = 0,
                    MenuDate = new DateTime(1998,3,7),
                    MenuStatus = MenuStatus.Closed.ToString()                   
                },
                new MenuDto
                {
                    MenuId = 1,    
                    MenuDate = new DateTime(2018,10,24),
                    MenuStatus = MenuStatus.Active.ToString()
                },
            };
        }

    }
}
