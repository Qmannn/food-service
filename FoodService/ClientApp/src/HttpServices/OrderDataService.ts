import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpParams } from '@angular/common/http';
import { DayMenuDto } from '../dto/DayMenu/DayMenuDto';
import { OrderDto } from '../dto/Order/OrderDto';

@Injectable()
export class OrderDataService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getDishes(menuDate: Date): Observable<DayMenuDto> {
    const params: HttpParams = new HttpParams()
      .set('menuDate', menuDate.toDateString());
    return this._httpService.get<DayMenuDto>('api/Order/menu-on-day', params);
  }
  public makeOrder(order: OrderDto): Observable<OrderDto> {
    return this._httpService.post<OrderDto, OrderDto>('api/Order/make-order', order);
  }
}
