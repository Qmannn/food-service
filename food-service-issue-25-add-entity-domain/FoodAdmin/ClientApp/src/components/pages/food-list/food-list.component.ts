import { Component } from '@angular/core';
import { SampleDataService } from '../../../HttpServices/SampleDataService';
import { SampleDto } from '../../../dto/Sample/SampleDto';

@Component({
  // selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  providers: [SampleDataService]
})
export class FoodListComponent {
  private readonly _sampleDataService: SampleDataService;
  public countAll = 0;
  public samples: SampleDto[];

  public constructor(sampleDataService: SampleDataService) {
    this._sampleDataService = sampleDataService;

    this._sampleDataService.getSamples().subscribe(values => {
      this.countAll = values.length;
      this.samples = values;
    });
  }
}
