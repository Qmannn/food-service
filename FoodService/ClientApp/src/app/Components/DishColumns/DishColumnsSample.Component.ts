import { Component } from '@angular/core';
import { DishDto } from '../../../dto/Dish/DishDto';
import { DishCategory } from '../../../dto/Dish/DishCategory';

@Component({
  selector: 'app-dish-columns-sample',
  templateUrl: './DishColumnsSample.Component.html',
  styleUrls: ['./DishColumnsSample.Component.css']
})
export class DishColumnsSapmleComponent {

  public dishList: DishDto[] = this.getMock();

  private getMock(): DishDto[] {
    const dishDto1: DishDto = new DishDto();
    dishDto1.dishId = 0;
    dishDto1.name = 'Soup 1';
    dishDto1.description = ' dish description';
    dishDto1.price = 100;
    dishDto1.category = DishCategory.Soup;
    dishDto1.containerId = 1;

    const dishDto2: DishDto = new DishDto();
    dishDto2.dishId = 1;
    dishDto2.name = 'Second dish 1';
    dishDto2.description = ' dish description';
    dishDto2.price = 100;
    dishDto2.category = DishCategory.SecondDish;
    dishDto2.containerId = 1;

    const dishDto3: DishDto = new DishDto();
    dishDto3.dishId = 2;
    dishDto3.name = 'Garnish 1';
    dishDto3.description = ' dish description';
    dishDto3.price = 100;
    dishDto3.category = DishCategory.Garnish;
    dishDto3.containerId = 1;

    const dishDto4: DishDto = new DishDto();
    dishDto4.dishId = 3;
    dishDto4.name = 'Salad 1';
    dishDto4.description = ' dish description';
    dishDto4.price = 100;
    dishDto4.category = DishCategory.Salad;
    dishDto4.containerId = 1;

    const dishDto5: DishDto = new DishDto();
    dishDto5.dishId = 4;
    dishDto5.name = 'Soup 2';
    dishDto5.description = ' dish description';
    dishDto5.price = 100;
    dishDto5.category = DishCategory.Soup;
    dishDto5.containerId = 1;

    const dishDto6: DishDto = new DishDto();
    dishDto6.dishId = 5;
    dishDto6.name = 'Salad 2';
    dishDto6.description = ' dish description';
    dishDto6.price = 100;
    dishDto6.category = DishCategory.Salad;
    dishDto6.containerId = 1;

    const dishDto7: DishDto = new DishDto();
    dishDto7.dishId = 6;
    dishDto7.name = 'Garnish 2';
    dishDto7.description = ' dish description';
    dishDto7.price = 100;
    dishDto7.category = DishCategory.Garnish;
    dishDto7.containerId = 1;

    return [dishDto1, dishDto2, dishDto3, dishDto4, dishDto5, dishDto6, dishDto7];
  }
}
