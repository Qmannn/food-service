import { Component } from '@angular/core';
import { DishesService } from '../../../HttpServices/DishesService/DishesService';
import { DishDto } from '../../../dto/DishDto/DishDto';
import { DishType } from '../../../dto/DishDto/Enum/DishType'

@Component({
  // selector: 'app-food-list',
  templateUrl: './DishList.Component.html',
  providers: [DishesService]
})

export class DishListComponent {
  private readonly _dishesService: DishesService;
  public dishes: DishDto[];

  public constructor(DishesService: DishesService) {
    this._dishesService = DishesService;

    this._dishesService.getDishes().subscribe(values => {
      this.dishes = values;
    });
  }

  public getDishType(Type: DishType): string {
    switch (Type) {
      case DishType.Salad: {
        return 'Салат';
      }

      case DishType.Soup: {
        return 'Суп';
      }

      case DishType.SecondDish: {
        return 'Второе блюдо';
      }

      case DishType.Garnish: {
        return 'Гарнир';
      }

      default: {
        return '';
      }
    }
  }
}
