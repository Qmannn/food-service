import { Component } from '@angular/core';
import { SampleDataService } from '../../../HttpServices/SampleDataService';
import { SampleDto } from '../../../dto/Sample/SampleDto';

@Component({
    // selector: 'app-sample', // Обязательное поле, должно начинаться с app-
    templateUrl: './Sample.Component.html',
    providers: [SampleDataService]
})
export class SampleComponent {
    private readonly _sampleDataService: SampleDataService;
    public samples: SampleDto[];

    public sampleToEdit: SampleDto;

    public constructor(sampleDataService: SampleDataService) {
        this._sampleDataService = sampleDataService;

        this._sampleDataService.getSamples().subscribe(values => {
            this.samples = values;
        });
    }

    public editSample(sampleId: number): void {
        this._sampleDataService.getSample(sampleId).subscribe(value => {
            this.sampleToEdit = value;
            alert(`Edit ${sampleId}`);
        });
    }

    public saveSample(): void {
        this._sampleDataService.saveSample(this.sampleToEdit).subscribe(value => {
            alert('Сохранен ' + value.savedSampleId + 'c описаним "' + value.savedDescription + '"');
        });
    }

    public deleteSample(sampleId: number): void {
        alert(`Delete ${sampleId}`);
    }
}
