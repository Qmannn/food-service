import { Component, Input, EventEmitter, Output } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
  selector: 'app-column-dishes',
  templateUrl: './DishesColumn.Component.html',
  styleUrls: ['./DishesColumn.Component.css']
})

export class DishesColumnComponent {
  @Input()
  public dishes: DishDto[];
  @Output()
  public dishSelected: EventEmitter<DishDto> = new EventEmitter<DishDto>();

  protected selectDish(dish: DishDto): void {
    this.dishSelected.emit(dish);
  }
}
