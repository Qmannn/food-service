import { HttpService } from './HttpService';
import { Injectable, Inject } from '@angular/core';
import { UserDto } from '../dto/User/UserDto';
import { Observable } from 'rxjs';

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
