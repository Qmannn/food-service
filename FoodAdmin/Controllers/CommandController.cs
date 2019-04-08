using System.Collections.Generic;
using FoodAdmin.Dto.Command;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        private readonly ICommandsService _commandService;

        public CommandController(ICommandsService commandService)
        {
            _commandService = commandService;
        }

        [HttpGet("")]
        public List<CommandDto> GetCommands()
        {
            return _commandService.GetCommands();                     
        }


        [HttpPost("delete-command")]
        public DeletedCommandInfo DeleteCommand([FromBody] int commandId)
        {
            _commandService.DeleteCommand(commandId);

            return new DeletedCommandInfo
            {
                DeletedCommandId = commandId,
                DeletedDescription = "sucsess deleted"
            };

        }

        [HttpGet("get-command")]
        public CommandDto GetCommand(int commandId)
        {
            return _commandService.GetCommand(commandId);
        }

        [HttpPost("save-command")]
        public SavedCommandInfo SaveSample([FromBody] CommandDto command)
        {
            CommandDto savedCommandDto = _commandService.SaveCommand(command);

            return new SavedCommandInfo
            {
                SavedCommandId = savedCommandDto.CommandId,
                SavedDescription = savedCommandDto.Description
            };
        }
    }
}