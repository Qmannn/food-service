import { Component } from '@angular/core';
import { DishDataService } from '../../../HttpServices/DishDataService';
import { DishDto } from '../../../dto/Dish/DishDto';
import { ContainerDto } from '../../../dto/Container/ContainerDto';

@Component({
  selector: 'app-dish',
  templateUrl: './Dish.component.html',
  providers: [DishDataService]
})
export class DishComponent {

  dishId = 1;
  name = 'Борщ';
  description = 'Очень вкусный';
  price = 159;
  dishType = 'Суп';
  containerId = 3;
  
  private readonly _dishDataService: DishDataService;
  public countAll = 0;
  public containers: ContainerDto[];
  
  public constructor(dishDataService: DishDataService) {
    this._dishDataService = dishDataService;

    this._dishDataService.getContainers().subscribe(values => {
      this.countAll = 3;
      this.containers = values;
    });
  }
}
