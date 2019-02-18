import { Component, Input } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishCategory } from '../../../dto/Dish/DishCategory';

@Component({
  selector: 'app-dish-columns',
  templateUrl: './DishColumns.Component.html',
  styleUrls: ['./DishColumns.Component.css']
})
export class DishColumnsComponent {

  @Input()
  public dishList: DishDto[];

  private getDishList(category: DishCategory): DishDto[] {
    const result: DishDto[] = [];
    for (let i = 0; i < this.dishList.length; i++) {
      if (this.dishList[i].category === category) {
        result.push(this.dishList[i]);
      }
    }

    return result;
  }

  protected get saladItems(): DishDto[] {
    return this.getDishList(DishCategory.Salad);
  }

  protected get firstDishItems(): DishDto[] {
    return this.getDishList(DishCategory.Soup);
  }

  protected get secondDishItems(): DishDto[] {
    return this.getDishList(DishCategory.SecondDish);
  }

  protected get garnishItems(): DishDto[] {
    return this.getDishList(DishCategory.Garnish);
  }
}
