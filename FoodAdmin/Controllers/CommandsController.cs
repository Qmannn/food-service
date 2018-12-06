using System;
using System.Collections.Generic;
using FoodAdmin.Dto.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class CommandsController : Controller
    {
        [HttpGet("")]
        public List<CommandsDto> GetUsers()
        {
            return new List<CommandsDto>
            {
                new CommandsDto
                {
                    CommandsId = 1,
                    Name = "������ �������",
                    Description = "���������� ������ �������"
                },
                new CommandsDto
                {
                    CommandsId = 2,
                    Name = "������ �������",
                    Description = "���������� ������ �������"
                },
                new CommandsDto
                {
                    CommandsId = 3,
                    Name = "������ �������",
                    Description = "���������� ������� �������"
                }              
            };
        }
    }
}