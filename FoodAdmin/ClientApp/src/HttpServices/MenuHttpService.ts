import { MenuDto } from '../dto/Menu/MenuDto';
import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { MenuDishDto } from '../dto/MenuDIsh/MenuDishDto';
import { DishDto } from '../dto/Dish/DishDto';

@Injectable()
export class MenuHttpService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getMenu(menuId: number): Observable<MenuDto> {
    const params: HttpParams = new HttpParams()
      .set('menuId', menuId.toString());
    return this._httpService.get<MenuDto>('api/MenusApi/Menu', params);
  }

  public saveMenu(menu: MenuDto): Observable<MenuDto> {
    return this._httpService.post<MenuDto, MenuDto>('Api/MenusApi/Save', menu);
  }

  public getMenus(): Observable<MenuDto[]> {
      return this._httpService.get<MenuDto[]>('api/MenusApi/');
  }

  public getDishes(): Observable<DishDto[]> {
      return this._httpService.get<DishDto[]>('api/dish/dishes');
  }

  public getMenusDishes(menuId: number): Observable<DishDto[]> {
    const params: HttpParams = new HttpParams()
      .set('menuId', menuId.toString());
    return this._httpService.get<DishDto[]>('api/MenusApi/dishes', params);
  }

  public deleteMenu(id: number): Observable<void> {
    const params: HttpParams = new HttpParams().set('id', id.toString());
    return this._httpService.post('api/MenusApi/Remove', params);
  }
}
