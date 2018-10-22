import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, NgZone } from '@angular/core';
import { SampleDto } from '../dto/PageName/SampleDto';
import { IPromise, defer, Deferred } from 'q';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HttpService {
    private readonly _httpClient: HttpClient;
    private readonly _baseUrl: string;

    public constructor(httpService: HttpClient, @Inject('BASE_URL') baseUrl: string, private zone: NgZone) {
        this._httpClient = httpService;
        this._baseUrl = baseUrl;
    }

    public get<T>(url: string): Observable<T> {
        return this._httpClient.get<T>(this._baseUrl + url);
    }
}
