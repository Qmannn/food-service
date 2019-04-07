import { Component } from '@angular/core';
import { DishDto } from '../../dto/Dish/DishDto';
import { MockDataHelper } from '../Components/Pages/MockDataHelper';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
})

export class CounterComponent {
  public currentCount: number = 0;
  public selectDishes: DishDto[] = [];
  public dishes: DishDto[] = MockDataHelper.getMock();

  protected selectDish(dish: DishDto): void {
    this.selectDishes.push(dish);
  }

  protected deselectDish(dish: DishDto): void {
    const index: number = this.selectDishes.findIndex((item: DishDto) => item.id === dish.id);
    this.selectDishes.splice(index, 1);
  }

  protected selectDate(date: Date): void {
    alert(date);
  }
}
