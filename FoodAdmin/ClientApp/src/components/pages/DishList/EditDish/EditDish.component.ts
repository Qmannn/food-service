import { Component } from '@angular/core';
import { DishDataService } from '../../../../HttpServices/DishDataService';
import { DishDto } from '../../../../dto/Dish/DishDto';
import { DishCategory } from '../../../../dto/Dish/DishCategory';
import { ActivatedRoute } from '@angular/router';
import { IDishCategory } from '../EditDish/IDishCategoryName';
import { DishCategoryNameUtil } from '../EditDish/DishCategoryNameUtil';
import { ContainerHttpService } from '../../../../HttpServices/ContainerHttpService';
import { ContainerDto } from '../../../../dto/Container/ContainerDto';

@Component({
  templateUrl: './EditDish.Component.html',
  providers: [DishDataService, ContainerHttpService]
})

export class EditDishComponent {
  private readonly _dishDataService: DishDataService;
  private readonly _containerHttpService: ContainerHttpService;

  public categories: Array<IDishCategory>;

  public containers: ContainerDto[];
  public editingDishId: number;
  public dishToEdit: DishDto;

  public constructor(containerHttpService: ContainerHttpService, dishDataService: DishDataService, route: ActivatedRoute) {
    this._dishDataService = dishDataService;
    this.categories = DishCategoryNameUtil.getCategories();

    this._containerHttpService = containerHttpService;
    this._containerHttpService.getContainers().subscribe(values => {
      this.containers = values;
    });

    route.params.subscribe(params => {
      const paramsDishId: number | undefined = params['dishId'] !== undefined
        ? Number(params['dishId'])
        : 0;
      this.editingDishId = paramsDishId;
      this.loadDish();
    });
  }

  private loadDish(): void {
    this._dishDataService.getDish(this.editingDishId).subscribe(dish => {
      this.dishToEdit = dish;
    });
  }

  public saveDish(): void {
    this._dishDataService.saveDish(this.dishToEdit).subscribe(value => {
      this.editingDishId = value.dishId;
      this.loadDish();
    });
  }
}
