import { Component } from '@angular/core';
import { DishDataService } from '../../../../HttpServices/DishDataService';
import { DishDto } from '../../../../dto/Dish/DishDto';
import { DishCategory } from '../../../../dto/Dish/DishCategory';
import { ActivatedRoute } from '@angular/router';
import { IDishCategory } from '../DishCategory/IDishCategoryName';
import { DishCategoryNameUtil } from '../DishCategory/DishCategoryNameUtil';

@Component({
  templateUrl: './EditDish.Component.html',
  providers: [DishDataService]
})

export class EditDishComponent {
  private readonly _dishDataService: DishDataService;

  public categories: Array<IDishCategory>;

  public editingDishId: number;
  public dishToEdit: DishDto;

  public constructor(dishDataService: DishDataService, route: ActivatedRoute) {
    this._dishDataService = dishDataService;
    this.categories = DishCategoryNameUtil.getCategories();
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
