import { Component } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';


@Component({
    templateUrl: './DishSimple.Component.html',
    styleUrls: ['./DishSimple.Component.css'],
})

export class DishSimpleComponent {
    public dish: DishDto;
}
