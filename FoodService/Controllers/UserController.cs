using System;
using System.Collections.Generic;
using FoodService.Dto.User;
using FoodService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }

        [HttpGet("users")]
        public List<UserDto> GetUsers()
        {
            return _usersService.GetUsers();
        }
    }
}