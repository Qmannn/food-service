import { Component } from '@angular/core';
import { DishDto } from '../../../dto/DishDto/DishDto';
import { DishCategory } from '../../../dto/DishDto/Enum/DishCategory';
import { DishTypeNameResolver } from '../../../services/DishTypeNameResolver';
import { GetMock } from './GetMock';

@Component({
  selector: 'app-edit-menu',
  templateUrl: './EditMenu.Component.html'
})
export class EditMenuComponent {
  private readonly _resolver: DishTypeNameResolver = new DishTypeNameResolver();

  public dishes: DishDto[] = GetMock.getMock();
  public selectedDishes: DishDto[] = [];
  public selectedDate: Date = new Date;

  public addDish(dish: DishDto) {
    for (let i = 0; i < this.dishes.length; i++) {
      if (this.dishes[i].id === dish.id) {
        this.dishes.splice(i, 1);
        this.selectedDishes.push(dish);
        return 0;
      }
    }
  }

  public delDish(dish: DishDto) {
    for (let i = 0; i < this.selectedDishes.length; i++) {
      if (this.selectedDishes[i].id === dish.id) {
        this.selectedDishes.splice(i, 1);
        this.dishes.push(dish);
        return 0;
      }
    }
  }

  public getDishCategory(category: DishCategory) {
    return this._resolver.getDishCategory(category);
  }
}
