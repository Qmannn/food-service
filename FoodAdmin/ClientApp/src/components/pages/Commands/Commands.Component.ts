import { Component } from '@angular/core';
import { CommandDataService } from '../../../HttpServices/CommandDataService';
import { CommandDto } from '../../../dto/Command/CommandDto';

@Component({
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
    this._commandDataService.deleteCommand(commandId).subscribe(() => {
      this.reloadCommands();
    });
  }

  private reloadCommands(): void {
    this._commandDataService.getCommands().subscribe(commandsValues => {
      this.commands = commandsValues;
    });
  }

public editCommand(commandId: number): void {
    this._commandDataService.getCommand(commandId).subscribe(value => {
        this.commandToEdit = value;
        alert(`Edit ${commandId}`);
    });
}

public saveCommand(): void {
    this._commandDataService.saveCommand(this.commandToEdit).subscribe(value => {
        alert('Сохранен ' + value.savedCommandId + 'c описанием "' + value.savedDescription + '"');
        this.reloadCommands();
        this.commandToEdit = undefined;
    });
}
}
