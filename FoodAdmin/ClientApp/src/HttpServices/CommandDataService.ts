import { HttpService } from './HttpService';
import { Injectable, Inject } from '@angular/core';
import { CommandDto } from '../dto/Command/CommandDto';
import { DeletedCommandInfo } from '../dto/Command/DeletedCommandInfo';
import { SavedCommandInfo } from '../dto/Command/SavedCommandInfo';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class CommandDataService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getCommands(): Observable<CommandDto[]> {
        return this._httpService.get<CommandDto[]>('api/Command');
    }

    public deleteCommand(commandId: number): Observable<DeletedCommandInfo> {
        return this._httpService.post<number, DeletedCommandInfo>('api/Command/delete-command', commandId);
    }

    public getCommand(commandId: number): Observable<CommandDto> {
      const params: HttpParams = new HttpParams()
          .set('commandId', commandId.toString());
      return this._httpService.get<CommandDto>('api/Command/get-command', params);
  }

  public saveCommand(command: CommandDto): Observable<SavedCommandInfo> {
      return this._httpService.post<CommandDto, SavedCommandInfo>('api/Command/save-command', command);
  }
}
