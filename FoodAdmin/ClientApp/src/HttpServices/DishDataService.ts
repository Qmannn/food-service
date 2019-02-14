import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DishDto } from '../dto/Dish/DishDto';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class DishDataService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getDishes(): Observable<DishDto[]> {
    return this._httpService.get<DishDto[]>('api/Dish/Dishes');
  }

  public getDish(dishId: number): Observable<DishDto> {
    const params: HttpParams = new HttpParams()
      .set('dishId', dishId.toString());
    return this._httpService.get<DishDto>('api/Dish/Dish', params);
  }

  public saveDish(dish: DishDto): Observable<DishDto> {
    return this._httpService.post<DishDto, DishDto>('api/Dish/Save', dish);
  }

  public removeDish(dishId: number): Observable<void> {
    const params: HttpParams = new HttpParams()
      .set('dishId', dishId.toString());
    return this._httpService.post('api/Dish/remove', params);
  }
}
