import { Component, Input } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';

@Component({
  selector: 'app-dish-column-sample',
  templateUrl: './DishColumnSample.Component.html',
  styleUrls: ['./DishColumnSample.Component.css']
})
export class DishColumnSampleComponent {

    @Input()
    public dishes: DishDto[];
}
