import { Component } from '@angular/core';
import { FoodListService } from '../../../HttpServices/FoodListService/FoodListService';
import { FoodListDto } from '../../../dto/FoodListDto/FoodListDto';

@Component({
  // selector: 'app-food-list',
  templateUrl: './FoodList.Component.html',
  providers: [FoodListService]
})
export class FoodListComponent {
  private readonly _FoodListService: FoodListService;
  public FoodList: FoodListDto[];

  public constructor(FoodListService: FoodListService) {
    this._FoodListService = FoodListService;

    this._FoodListService.getFoodList().subscribe(values => {
      this.FoodList = values;
    });
  }
}
