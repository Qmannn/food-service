import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UserDto } from '../dto/User/UserDto';
import { EditUserDto } from '../dto/EditUser/EditUserDto';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class EditUserDataService {
  private readonly _httpService: HttpService;
  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public addUser(user: EditUserDto): Observable<EditUserDto> {
    return this._httpService.post<UserDto, EditUserDto>('api/EditUser/User', user);
  }

  public getUser(userId: number): Observable<EditUserDto> {
    const params: HttpParams = new HttpParams()
      .set('userId', userId.toString());
    return this._httpService.get<EditUserDto>('api/EditUser/User', params);
  }
}
