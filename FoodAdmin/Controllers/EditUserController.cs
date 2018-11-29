using System;
using System.Collections.Generic;
using FoodAdmin.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class EditUserController : Controller
    {
        [HttpGet("user")]
        public UserDto GetUser(int userId)
        {
            return new UserDto
            {
                UserId = userId,
                Name = "",
                UserName = ""
            };
        }

        [HttpPost("user")]
        public UserDto SaveUser([FromBody] UserDto newUser)
        {
            return new UserDto
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                UserName = newUser.UserName,
            };
        }
    }
}