import { Component, Input } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
    selector: 'app-dish-card',
    templateUrl: './DishCard.Component.html',
    styleUrls: ['./DishCard.Component.css']
})

export class DishCardComponent {
    @Input()
    public dish: DishDto;
}
