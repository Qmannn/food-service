import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable, NgZone } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HttpService {
    private readonly _httpClient: HttpClient;
    private readonly _baseUrl: string;

    public constructor(httpService: HttpClient, @Inject('BASE_URL') baseUrl: string, private zone: NgZone) {
        this._httpClient = httpService;
        this._baseUrl = baseUrl;
    }

    public get<T>(url: string, params?: HttpParams): Observable<T> {
        const httpHeaders = new HttpHeaders().set('Accept', 'application/json');
        return this._httpClient.get<T>(this._baseUrl + url, {headers: httpHeaders, params: params});
    }

    public post<TRq, TRs>(url: string, body: TRq): Observable<TRs> {
        return this._httpClient.post<TRs>(this._baseUrl + url, body);
    }
}
