import { Component } from '@angular/core';
import { CommandDataService } from '../../../HttpServices/CommandDataService';
import { CommandDto } from '../../../dto/Command/CommandDto';

@Component({
  selector: 'app-commands',
  templateUrl: './Commands.Component.html',
  providers: [CommandDataService]
})
export class CommandsComponent {
  private readonly _commandDataService: CommandDataService;
  public commands: CommandDto[];
  public commandToEdit: CommandDto;

  public constructor(commandDataService: CommandDataService) {
    this._commandDataService = commandDataService;

    this.reloadCommands();
  }

  public deleteCommand(commandId: number): void {
    alert('Delete' + commandId);
    this._commandDataService.deleteCommand(this.commandToEdit);
    this.reloadCommands();  
  }

  private reloadCommands(): void {
    this._commandDataService.getCommands().subscribe(commandsValues => {
      this.commands = commandsValues;
    });
  }
};

  