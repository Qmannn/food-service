import { MenuDto } from '../dto/Menu/MenuDto';
import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DishDto } from '../dto/DishDto/DishDto';

@Injectable()
export class MenuHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getMenus(): Observable<MenuDto[]> {
        return this._httpService.get<MenuDto[]>('api/MenusApi/');
    }

    public getDishes(): Observable<DishDto[]> {
        return this._httpService.get<DishDto[]>('api/MenusApi/dishes');
    }
}
