import { SampleDto } from '../dto/PageName/SampleDto';
import { IPromise } from 'q';
import { HttpService } from './BaseHttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SampleDataHttpService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getSamples(): Observable<SampleDto[]> {
        return this._httpService.get<SampleDto[]>('api/SampleData/Samples');
    }
}
