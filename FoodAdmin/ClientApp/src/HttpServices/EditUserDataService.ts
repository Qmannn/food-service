import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UserDto } from '../dto/User/UserDto';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class EditUserDataService {
  private readonly _httpService: HttpService;
  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public saveUser(user: UserDto): Observable<UserDto> {
    return this._httpService.post<UserDto, UserDto>('api/Users/User', user);
  }

  public getUser(userId: number): Observable<UserDto> {
    const params: HttpParams = new HttpParams()
      .set('userId', userId.toString());
    return this._httpService.get<UserDto>('api/Users/User', params);
  }
}
