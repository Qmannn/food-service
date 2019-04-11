import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpParams } from '@angular/common/http';
import { DayMenuDto } from '../dto/DayMenu/DayMenuDto';

@Injectable()
export class OrderDataService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getDishes(menuDate: Date): Observable<DayMenuDto> {
    const params: HttpParams = new HttpParams()
      .set('menuDate', menuDate.toDateString());
    return this._httpService.get<DayMenuDto>('api/Order/menu-on-day');
  }
}
