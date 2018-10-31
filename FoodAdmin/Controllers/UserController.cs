using System;
using System.Collections.Generic;
using FoodAdmin.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet("users")]
        public List<UserDto> GetUsers()
        {
            return new List<UserDto>
            {
                new UserDto
                {
                    UserId = 1,
                    Name = "First name",
                    Team = "First team",
                    Group = "First group"
                },
                new UserDto
                {
                    UserId = 2,
                    Name = "Second name",
                    Team = "Second team",
                    Group = "Second group"
                },
                new UserDto
                {
                    UserId = 3,
                    Name = "Test1",
                    Team = "First description",
                    Group = "3"
                },
                new UserDto
                {
                    UserId = 4,
                    Name = "Test1",
                    Team = "First description",
                    Group = "4"
                },
                new UserDto
                {
                    UserId = 5,
                    Name = "Test1",
                    Team = "First description",
                    Group = "5"
                },
            };
        }
    }
}