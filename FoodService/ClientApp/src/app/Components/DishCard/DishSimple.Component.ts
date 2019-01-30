import { Component } from "@angular/core";
import { DishDto } from "../../../dto/Dish/DishDto";
import { DishCardComponent } from "./DishCard.Component";


@Component({
    //selector: 'app-simple',
    templateUrl: './DishSimple.Component.html',
})

export class DishSimpleComponent {
    public dish: DishDto;
}