import { Component } from '@angular/core';
import { CommandDataService } from '../../../../HttpServices/CommandDataService';
import { CommandDto } from '../../../../dto/Command/CommandDto';
import { ActivatedRoute } from '@angular/router';

@Component({
        templateUrl: './EditCommands.Component.html',
        providers: [CommandDataService]
    })
export class EditCommandComponent {
    private readonly _commandDataService: CommandDataService;

    public editingCommandId: number;
    public commandToEdit: CommandDto;

    public constructor(commandDataService: CommandDataService, route: ActivatedRoute) {
        this._commandDataService = commandDataService;
        route.params.subscribe(params => {
            // Если в параметрах есть sampleId -то это редактирование, иначе это создание нового экземпляра
            const paramsCommandId: number | undefined = params['commandId'] !== undefined
                ? Number(params['commandId'])
                : 0;
            this.editingCommandId = paramsCommandId;
            this.commandToEdit = new CommandDto();
            this.loadCommand();
        });
    }

    private loadCommand(): void {
        this._commandDataService.getCommand(this.editingCommandId).subscribe(command => {
            this.commandToEdit = command;
        });
    }

    public saveCommand(): void {
        this._commandDataService.saveCommand(this.commandToEdit).subscribe(value => {
            this.editingCommandId = value.savedCommandId;
            alert('Сохраненo');
            this.loadCommand();
        });
    }
}
