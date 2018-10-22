import { Component } from '@angular/core';
import { SampleDataHttpService } from '../../../HttpServices/SampleDataHttpService';
import { SampleDto } from '../../../dto/PageName/SampleDto';

@Component({
  selector: 'app-food-list',
  templateUrl: './food-list.component.html',
  providers: [SampleDataHttpService]
})
export class FoodListComponent {
  private readonly _sampleDataService: SampleDataHttpService;
  public countAll = 0;
  public samples: SampleDto[];

  public constructor(sampleDataService: SampleDataHttpService) {
    this._sampleDataService = sampleDataService;

    this._sampleDataService.getSamples().subscribe(values => {
      this.countAll = values.length;
      this.samples = values;
    });
  }
}
