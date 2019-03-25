import { HttpService } from './HttpService';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UserDto } from '../dto/User/UserDto';

@Injectable()
export class UsersDataService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getUsers(): Observable<UserDto[]> {
        return this._httpService.get<UserDto[]>('api/Users/users');
    }
}
