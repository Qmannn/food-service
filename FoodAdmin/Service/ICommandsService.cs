using System.Collections.Generic;
using FoodAdmin.Dto.Command;

namespace FoodAdmin.Service
{
    public interface ICommandsService
    {
        CommandDto GetCommand(int commandId);
        List<CommandDto> GetCommands();
        void DeleteCommand(int commandId);
        CommandDto SaveCommand(CommandDto commandDto);
    }
}