import { ContainerDto } from '../dto/Container/ContainerDto';
import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class ContainerHttpService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getContainers(): Observable<ContainerDto[]> {
    return this._httpService.get<ContainerDto[]>('api/Container/containers');
  }

  public removeContainer(id: number): Observable<void> {
    const params: HttpParams = new HttpParams().set('id', id.toString());
    return this._httpService.post('api/Container/remove', params);
  }

  public getContainer(containerId: number): Observable<ContainerDto> {
    const params: HttpParams = new HttpParams().set('containerId', containerId.toString());

    return this._httpService.get<ContainerDto>('api/Container/container', params);
  }

  public saveContainer(container: ContainerDto): Observable<ContainerDto> {
    return this._httpService.post<ContainerDto, ContainerDto>('api/Container/container', container);
  }
}
