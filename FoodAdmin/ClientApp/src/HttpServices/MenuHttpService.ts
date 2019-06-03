import { MenuDto } from '../dto/Menu/MenuDto';
import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { MenuDishDto } from '../dto/Menu/MenuDishDto';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { MenuDishDto } from '../dto/MenuDIsh/MenuDishDto';


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

  
  public getDishes(menuId: number): Observable<MenuDishDto> {
      const params: HttpParams = new HttpParams()
          .set('menuId', menuId.toString());
      return this._httpService.get<MenuDishDto>('api/MenusApi/dishes', params);
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

  public addMenuDish(menuDish: MenuDishDto): Observable<MenuDishDto> {
    return this._httpService.post<MenuDishDto, MenuDishDto>('api/MenusApi/addMenuDish', menuDish);
  }

  public deleteMenu(id: number): Observable<void> {
    const params: HttpParams = new HttpParams().set('id', id.toString());
    return this._httpService.post('api/MenusApi/Remove', params);
  }
}
