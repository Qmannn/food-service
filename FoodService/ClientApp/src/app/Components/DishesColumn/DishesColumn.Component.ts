import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-column-dishes',
  templateUrl: './DishesColumn.Component.html',
  styleUrls: ['./DishesColumn.Component.css']
})

export class DishesColumnComponent {
  @Input()
  public dishes: string[];
}
