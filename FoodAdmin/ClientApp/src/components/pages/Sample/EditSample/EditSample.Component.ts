import { Component } from '@angular/core';
import { SampleDataService } from '../../../../HttpServices/SampleDataService';
import { SampleDto } from '../../../../dto/Sample/SampleDto';
import { ActivatedRoute } from '@angular/router';

@Component({
        templateUrl: './EditSample.Component.html',
        providers: [SampleDataService]
    })
export class EditSampleComponent {
    private readonly _sampleDataService: SampleDataService;

    public editingSampleId: number;
    public sampleToEdit: SampleDto;

    public constructor(sampleDataService: SampleDataService, route: ActivatedRoute) {
        this._sampleDataService = sampleDataService;
        route.params.subscribe(params => {
            // Если в параметрах есть sampleId -то это редактирование, иначе это создание нового экземпляра
            const paramsSampleId: number | undefined = params['sampleId'] !== undefined
                ? Number(params['sampleId'])
                : 0;
            this.editingSampleId = paramsSampleId;
            this.sampleToEdit = new SampleDto();
            // this.loadSample();
        });
    }

    private loadSample(): void {
        this._sampleDataService.getSample(this.editingSampleId).subscribe(sample => {
            this.sampleToEdit = sample;
        });
    }

    public saveSample(): void {
        this._sampleDataService.saveSample(this.sampleToEdit).subscribe(value => {
            this.editingSampleId = value.savedSampleId;
            this.loadSample();
        });
    }
}
