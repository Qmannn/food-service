using System.Collections.Generic;
using FoodAdmin.Dto.Command;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        [HttpGet("")]
        public List<CommandDto> GetCommands()
        {
            return new List<CommandDto>
            {
                new CommandDto
                {
                    CommandId = 1,
                    Name = "Первая команда",
                    Description = "Выполнение первой команды"
                },
                new CommandDto
                {
                    CommandId = 2,
                    Name = "Вторая команда",
                    Description = "Выполнение второй команды"
                },
                new CommandDto
                {
                    CommandId = 3,
                    Name = "Третья команда",
                    Description = "Выполнение третьей команды"
                }
            };
        }
        [HttpPost("delete-command")]
        public DeletedCommandInfo DeleteCommand([FromBody] CommandDto command)
        {            
            return new DeletedCommandInfo
            {
                DeletedCommandId = command.CommandId,
                DeletedDescription = command.Description
            };
        }
    }
}