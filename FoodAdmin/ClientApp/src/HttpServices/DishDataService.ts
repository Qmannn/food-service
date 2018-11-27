import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DishDto } from '../dto/Dish/DishDto';
import { HttpParams } from '@angular/common/http';
import { SavedDishInfo } from '../dto/Dish/SavedDishInfo';

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

  public saveDish(dish: DishDto): Observable<SavedDishInfo> {
    return this._httpService.post<DishDto, SavedDishInfo>('api/Dish/Dish', dish);
  }
}
