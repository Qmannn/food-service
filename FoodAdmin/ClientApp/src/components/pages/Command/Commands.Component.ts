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
  public command: CommandDto[];

  public constructor(commandDataService: CommandDataService) {
    this._commandDataService = commandDataService;

    this.reloadCommand();
  }

  public deleteCommand(commandId: number): void {
    alert(`Delete ${commandId}`);
    this.reloadCommand();  
  }

  private reloadCommand(): void {
    this._commandDataService.getCommand().subscribe(values => {
      this.command = values;
    });
  }
};

  