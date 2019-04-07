import { Component, Input, Output, EventEmitter } from '@angular/core';
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
  @Output()
  public dishSelected: EventEmitter<DishDto> = new EventEmitter<DishDto>();

  private getDishList(category: DishCategory): DishDto[] {
    const result: DishDto[] = [];
    const length: number = this.dishList.length;
    for (let i = 0; i < length; i++) {
      const dishDto: DishDto = this.dishList[i];
      if (dishDto.category === category) {
        result.push(dishDto);
      }
    }

    return result;
  }

  protected selectDish(dish: DishDto): void {
    this.dishSelected.emit(dish);
  }

  protected get saladItems(): DishDto[] {
    return this.getDishList(DishCategory.Salad);
  }

  protected get firstDishItems(): DishDto[] {
    return this.getDishList(DishCategory.FirstDish);
  }

  protected get secondDishItems(): DishDto[] {
    return this.getDishList(DishCategory.SecondDish);
  }

  protected get garnishItems(): DishDto[] {
    return this.getDishList(DishCategory.Garnish);
  }
}
