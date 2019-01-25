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

        [HttpGet("users")]
        public List<UserDto> GetUsers()
        {
            return _usersService.GetUsers();
        }

        [HttpGet("user")]
        public UserDto GetUser(int userId)
        {
            return _usersService.GetUser(userId);
        }

        [HttpPost("user")]
        public UserDto SaveUser([FromBody] UserDto newUser)
        {
            UserDto savedUserDto = _usersService.SaveUser(newUser);

            return new UserDto
            {
                UserId = savedUserDto.UserId,
                Name = savedUserDto.Name,
                Role = savedUserDto.Role
            };
        }
    }
}