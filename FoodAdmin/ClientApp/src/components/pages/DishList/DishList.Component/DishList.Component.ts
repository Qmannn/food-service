import { Component } from '@angular/core';
import { DishTypeNameResolver } from '../../../../services/DishTypeNameResolver';
import { DishCategory } from '../../../../dto/Dish/DishCategory';
import { DishDto } from '../../../../dto/Dish/DishDto';
import { DishDataService } from '../../../../HttpServices/DishDataService';

@Component({
  selector: 'app-dish-list',
  templateUrl: './DishList.Component.html',
  providers: [DishDataService]
})

export class DishListComponent {
  private readonly _dishDataService: DishDataService;
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  public dishes: DishDto[];

  public constructor(dishesService: DishDataService) {
    this._dishDataService = dishesService;

    this._dishDataService.getDishes().subscribe(values => {
      this.dishes = values;
    });
    this.reloadDishes();
  }

  public deleteDish(id: number): void {
    this._dishDataService.removeDish(id).subscribe(() => {
      this.reloadDishes();
    });
  }

  private reloadDishes(): void {
    this._dishDataService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }

  public getDishCategory(category: DishCategory): string {
    return this._resolver.getDishCategory(category);
  }
}
