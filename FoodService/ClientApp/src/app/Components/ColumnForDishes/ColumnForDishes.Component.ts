import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-column-dishes',
  templateUrl: './ColumnForDishes.Component.html',
  styleUrls: ['./ColumnForDishes.Component.css']
})
export class ColumnForDishesComponent {
  @Input()
  public dishes: string[];
}
