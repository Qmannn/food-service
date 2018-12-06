import { HttpService } from './HttpService';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { CommandsDto } from '../dto/Commands/CommandsDto';


@Injectable()
export class CommandsDataService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }
    
    public getCommands(): Observable<CommandsDto[]> {
        return this._httpService.get<CommandsDto[]>('api/Commands');
    }
}
