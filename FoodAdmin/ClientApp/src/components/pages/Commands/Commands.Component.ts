import { Component } from '@angular/core';
import { CommandsDataService } from '../../../HttpServices/CommandsDataService';
import { CommandsDto } from '../../../dto/Commands/CommandsDto';

@Component({
  selector: 'app-commands',
  templateUrl: './Commands.Component.html',
  providers: [CommandsDataService]
})
export class CommandsComponent {
  private readonly _commandsDataService: CommandsDataService;
  public commands: CommandsDto[];

  public constructor(commandsDataService: CommandsDataService) {
    this._commandsDataService = commandsDataService;

    this.reloadCommands();
  }

  public deleteCommands(commandsId: number): void {
    alert(`Delete ${commandsId}`);
    this.reloadCommands();  
  }

  private reloadCommands(): void {
    this._commandsDataService.getCommands().subscribe(values => {
      this.commands = values;
    });
  }
};

  