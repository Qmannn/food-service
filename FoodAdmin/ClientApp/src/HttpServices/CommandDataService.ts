import { HttpService } from './HttpService';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { CommandDto } from '../dto/Command/CommandDto';
import { DeletedCommandInfo } from '../dto/Command/DeletedCommandInfo';


@Injectable()
export class CommandDataService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }
    
    public getCommands(): Observable<CommandDto[]> {
        return this._httpService.get<CommandDto[]>('api/Command');
    }
   
    public deleteCommand(command: CommandDto):Observable<DeletedCommandInfo> {        
        return this._httpService.post<CommandDto, DeletedCommandInfo>('api/Command/delete-command', command);
    }      
}
