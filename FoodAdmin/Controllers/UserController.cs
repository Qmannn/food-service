using System;
using System.Collections.Generic;
using FoodAdmin.Dto.User;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }

        [HttpGet("")]
        public List<UserDto> GetUsers()
        {
            return _usersService.GetUsers();
        }
    }
}