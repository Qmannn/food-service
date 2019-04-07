import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
    selector: 'app-dish-card',
    templateUrl: './DishCard.Component.html',
    styleUrls: ['./DishCard.Component.css']
})

export class DishCardComponent {
    @Input()
    public dish: DishDto;
    @Output()
    public dishSelected: EventEmitter<DishDto> = new EventEmitter<DishDto>();

    protected selectDish(): void {
        this.dishSelected.emit(this.dish);
    }
}
