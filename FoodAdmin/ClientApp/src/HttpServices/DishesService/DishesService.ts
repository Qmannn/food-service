import { HttpService } from '../HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { DishDto } from '../../dto/DishDto/DishDto';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class DishesService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getDishes(): Observable<DishDto[]> {
    return this._httpService.get<DishDto[]>('api/DishesApi/dishlist');
  }

  public sendDishes(): void {
    
  }
}
