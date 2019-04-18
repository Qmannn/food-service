import { MenuDto } from '../dto/Menu/MenuDto';
import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { MenuDishDto } from '../dto/Menu/MenuDishDto';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class MenuHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getMenus(): Observable<MenuDto[]> {
        return this._httpService.get<MenuDto[]>('api/MenusApi/');
    }

    public getDishes(menuId: number): Observable<MenuDishDto> {
        const params: HttpParams = new HttpParams()
            .set('menuId', menuId.toString());
        return this._httpService.get<MenuDishDto>('api/MenusApi/dishes', params);
    }
}
