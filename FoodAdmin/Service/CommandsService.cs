using System;
using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.Command;

namespace FoodAdmin.Service
{
    public class CommandsService : ICommandsService
    {
        private readonly IRepository<Command> _commandRepository;

        public CommandsService( IRepository<Command> commandRepository )
        {
            _commandRepository = commandRepository;
        }

        public void DeleteCommand(int commandId)
        {
            //удаление из бд строку команды по commandId       
            _commandRepository.Delete(commandId);                      
        }

        public List<CommandDto> GetCommands()
        {
            List<Command> commands = _commandRepository.All.ToList();
            return commands.ConvertAll(Convert);
        }

        public CommandDto GetCommand( int commandId )
        {
            if (commandId == 0 )
            {
                return CreateCommand();
            }

            Command command = _commandRepository.All.FirstOrDefault(item => item.Id == commandId);
            if ( command != null )
            {
                return Convert( command );
            }

            return null;
        }

        public CommandDto SaveCommand(CommandDto commandDto )
        {
            Command command = _commandRepository.GetItem(commandDto.CommandId);

            if(command == null)
            {
                command = new Command();
            }
 
            command.Name = commandDto.Name;
            command.Description = commandDto.Description;

            command = _commandRepository.Save(command);

            return Convert(command);
        }

        public CommandDto CreateCommand()
        {
            return new CommandDto
            {
                CommandId = 0,
                Name = "Command",
                Description = "Описание созданной команды"
            };
        }

        private CommandDto Convert( Command command )
        {
            return new CommandDto
            {
                CommandId = command.Id,
                Name = command.Name,
                Description = command.Description
            };
        }
    }
}