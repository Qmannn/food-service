import { MenuDto } from '../dto/Menu/MenuDto';
import { IPromise } from 'q';
import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpParams } from '@angular/common/http';
import { MenuDishDto } from '../dto/Menu/MenuDishDto';

@Injectable()
export class MenuDataService {
   private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getDishes(menuId: number): Observable<MenuDishDto> {
    const params: HttpParams = new HttpParams()
        .set('menuId', menuId.toString());
    return this._httpService.get<MenuDishDto>('api/MenusApi/dishes', params);
}

  public getMenu(menuId: number): Observable<MenuDto> {
    const params: HttpParams = new HttpParams()
      .set('menuId', menuId.toString());
    return this._httpService.get<MenuDto>('api/Menus/Menu', params);
  }

  public getMenus(): Observable<MenuDto[]> {
      return this._httpService.get<MenuDto[]>('Api/Menus/');
  }

  public saveMenu(menu: MenuDto): Observable<MenuDto> {
    return this._httpService.post<MenuDto, MenuDto>('Api/Menus/Save', menu);
  }

  public deleteMenu(id: number): Observable<void> {
    const params: HttpParams = new HttpParams().set('id', id.toString());
    return this._httpService.post('api/Menus/Remove', params);
  }
}
