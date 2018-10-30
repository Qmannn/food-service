import { HttpService } from './HttpService';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { SampleDto } from '../dto/Sample/SampleDto';
import { HttpParams } from '@angular/common/http';
import { SavedSampleInfo } from '../dto/Sample/SavedSampleInfo';

@Injectable()
export class SampleDataService {
    private readonly _httpService: HttpService;

    public constructor(httpService: HttpService) {
        this._httpService = httpService;
    }

    public getSamples(): Observable<SampleDto[]> {
        return this._httpService.get<SampleDto[]>('api/Sample/Samples');
    }

    public getSample(sampleId: number): Observable<SampleDto> {
        // Устанавливаем необходимые параметры для запроса (контроллеру необхоим параметр sampleId)
        const params: HttpParams = new HttpParams()
            .set('sampleId', sampleId.toString());
        // get<SampleDto> - в треугольных скобках указан тип возвращаемого результата
        return this._httpService.get<SampleDto>('api/Sample/Sample', params);
    }

    public saveSample(sample: SampleDto): Observable<SavedSampleInfo> {
        // post<SampleDto, SavedSampleInfo> - в треугольных скобках первый параметр - тип тела запроса (передаваемый объект)
        // , второй параметр - тип возвращаемого результата
        return this._httpService.post<SampleDto, SavedSampleInfo>('api/Sample/Sample', sample);
    }
}
