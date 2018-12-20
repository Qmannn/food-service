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
        public EditUserDto GetUser(int userId)
        {
            return new EditUserDto
            {
                UserId = userId,
                Name = "",
                UserName = ""
            };
        }

        [HttpPost("user")]
        public EditUserDto SaveUser([FromBody] EditUserDto newUser)
        {
            return new EditUserDto
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                UserName = newUser.UserName,
            };
        }
    }
}