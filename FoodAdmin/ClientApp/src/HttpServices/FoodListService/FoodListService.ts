import { HttpService } from '../HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { FoodListDto } from '../../dto/FoodListDto/FoodListDto';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class FoodListService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getFoodList(): Observable<FoodListDto[]> {
    return this._httpService.get<FoodListDto[]>('api/FoodList/foodlist');
  }
}
