import { Component } from '@angular/core';
import { DishesService } from '../../../HttpServices/DishesService/DishesService';
import { DishDto } from '../../../dto/DishDto/DishDto';
import { DishCategory } from '../../../dto/DishDto/Enum/DishCategory';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';

@Component({
  // selector: 'app-food-list',
  templateUrl: './DishList.Component.html',
  providers: [DishesService]
})

export class DishListComponent {
  private readonly _dishesService: DishesService;
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver;
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

  public getDishCategory(category: DishCategory) {
    return this._resolver.getDishCategory(category);
  }
}
