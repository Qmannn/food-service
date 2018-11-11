import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DishDto } from '../dto/Dish/DishDto';
import { ContainerDto } from '../dto/Container/ContainerDto';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class DishDataService {
    private readonly _httpService: HttpService;

    public getContainers(): Observable<ContainerDto[]> {
      return this._httpService.get<ContainerDto[]>('api/Dish/Dishes');
    }

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }


  public getDish(dishId: number): Observable<DishDto> {

        const params: HttpParams = new HttpParams()
            .set('dishId', dishId.toString());

        return this._httpService.get<DishDto>('api/Dish/Dish', params);
    }
}
