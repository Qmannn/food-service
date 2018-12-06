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
            var storedUsers = _usersService.GetUsers();

            if (storedUsers.Count > 0)
            {
                return storedUsers;
            }

            return new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    Name = "First name",
                    Role = Food.EntityFramework.Entities.Enums.UserRole.Client
                },
                new UserDto
                {
                    Id = 2,
                    Name = "Second name",
                    Role = Food.EntityFramework.Entities.Enums.UserRole.Client
                },
                new UserDto
                {
                    Id = 3,
                    Name = "Test1",
                    Role = Food.EntityFramework.Entities.Enums.UserRole.Administrator
                },
            };
        }
    }
}