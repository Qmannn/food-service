import { Component, Input } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
  selector: 'app-column-dishes',
  templateUrl: './DishesColumn.Component.html',
  styleUrls: ['./DishesColumn.Component.css']
})

export class DishesColumnComponent {
  @Input()
  public dishes: DishDto[];
}
