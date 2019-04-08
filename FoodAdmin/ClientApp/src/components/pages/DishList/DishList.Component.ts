import { Component } from '@angular/core';
import { DishesService } from '../../../HttpServices/DishesService/DishesService';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { DishCategory } from '../../../dto/Dish/DishCategory';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
  // selector: 'app-food-list',
  templateUrl: './DishList.Component.html',
  providers: [DishesService]
})

export class DishListComponent {
  private readonly _dishesService: DishesService;
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();
  public dishes: DishDto[];

  public constructor(dishesService: DishesService) {
    this._dishesService = dishesService;

    this._dishesService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }

  public deleteDish(id: number): void {
    this._dishesService.removeDish(id).subscribe(() => {
      this.reloadDishes();
    });
  }

  private reloadDishes(): void {
    this._dishesService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }

  public getDishCategory(category: DishCategory): string {
    return this._resolver.getDishCategory(category);
  }
}
