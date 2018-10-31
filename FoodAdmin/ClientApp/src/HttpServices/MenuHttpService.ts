import { MenuDto } from '../dto/Menu/MenuDto';
import { IPromise } from 'q';
import { HttpService } from './BaseHttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MenuHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getMenus(): Observable<MenuDto[]> {
        return this._httpService.get<MenuDto[]>('api/MenusApi/menus');
    }
}
