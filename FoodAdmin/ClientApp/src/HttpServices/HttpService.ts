import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable, NgZone} from '@angular/core';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class HttpService {
    private readonly _httpClient: HttpClient;
    private readonly _baseUrl: string;
    private bodyElement = document.getElementsByClassName('body-content')[0];
    private preloaderElement = document.createElement('div');
    private errorElement = document.createElement('div');

    public constructor(httpService: HttpClient, @Inject('BASE_URL') baseUrl: string, private zone: NgZone) {
        this._httpClient = httpService;
        this._baseUrl = baseUrl;
    }

    private addDiv(element: HTMLDivElement, className: string): void {
        element.className = className;
        this.bodyElement.appendChild(element);
    }

    private removeDiv(element: HTMLDivElement): void {
        this.bodyElement.removeChild(element);
    }

    public get<T>(url: string, params?: HttpParams): Observable<T> {
        this.addDiv(this.preloaderElement, 'preloader');
        const httpHeaders = new HttpHeaders().set('Accept', 'application/json');
        return this._httpClient.get<T>(this._baseUrl + url, {headers: httpHeaders, params: params}).pipe(
            tap(_ => {
                this.removeDiv(this.preloaderElement);
            }, () => {
                this.removeDiv(this.preloaderElement);
            })
        );
    }

    public post<TRq, TRs>(url: string, body: TRq): Observable<TRs> {
        return this._httpClient.post<TRs>(this._baseUrl + url, body);
    }

    public delete<T, comamndId>(url: string, params?: HttpParams): Observable<T> {
        const httpHeaders = new HttpHeaders().set('Accept', 'application/json');
        return this._httpClient.delete<T>(this._baseUrl + url, {headers: httpHeaders, params: params});
    }
}
